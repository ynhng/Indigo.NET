﻿using Indigo.Infrastructure.Search;
using Indigo.Organization.Search;
using Indigo.Security.Data.Impl;
using NHibernate;
using Spring.Stereotype;

namespace Indigo.Organization.Data.Impl
{
    [Repository]
    public class EmployeeHibernateDao : GenericSecurityHibernateDao<Employee, string>, IEmployeeDao
    {
        public Employee GetByNumber(string number)
        {
            IQuery query = CreateQuery("from Employee where Number = :number").SetString("number", number);
            return query.UniqueResult<Employee>();
        }

        public Page<Employee> Search(EmployeeSearchForm searchForm)
        {
            IQueryOver<Employee, Employee> query = QueryOver();

            query = query.OrderBy(e => e.Created).Desc;

            return GetPage(query, searchForm);
        }
    }
}