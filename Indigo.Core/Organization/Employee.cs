﻿using System;
using Indigo.Security;

namespace Indigo.Organization
{
    /// <summary>
    /// 职员
    /// </summary>
    public class Employee : UserEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual string Number { get; set; }
        public virtual IdentityCard IdentityCard { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DateTime? Birthday { get; set; }
        public virtual int? Age { get; set; }
        public virtual Department Department { get; set; }
        public virtual Position Position { get; set; }
        public virtual User User { get; set; }

        public virtual void SetIdentityCardNumber(string identityCardNumber)
        {
            IdentityCard = new IdentityCard(identityCardNumber);
            Birthday = IdentityCard.GetBirthday();
            Age = IdentityCard.GetAge();
            Gender = IdentityCard.GetGender();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}