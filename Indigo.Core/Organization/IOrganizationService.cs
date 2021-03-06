﻿using System.Collections.Generic;
using Indigo.Infrastructure.Search;
using Indigo.Organization.Search;
using Indigo.Security;

namespace Indigo.Organization
{
    public interface IOrganizationService
    {
        Department AddDepartment(string name, string description, Department superDepartment, int ordinal, User oper);
        Department GetDepartmentById(string id);
        Department GetDepartmentById(string id, User oper);
        Department GetDepartmentByName(string name);
        IList<Department> GetRootDepartments();
        IList<Department> GetDepartments();
        IList<Department> GetDepartments(User oper);
        Page<Department> Search(DepartmentSearchForm searchForm);

        Position AddPosition(string name, int rank, User oper);
        Position GetPositionByName(string name);
        IList<Position> GetPositions();
        Position GetPositionById(string id);
        Page<Position> Search(PositionSearchForm searchForm);

        Employee AddEmployee(Employee employee, Department department, Position position, User oper);
        Employee GetEmployeeByNumber(string number);
        Page<Employee> Search(EmployeeSearchForm searchForm);
    }
}