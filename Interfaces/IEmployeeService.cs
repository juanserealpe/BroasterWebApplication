﻿using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

    public interface IEmployeeService
    {
        Task AddEmployeeAsync(Employee prmEmployee);
        Task<int> GetUserRoleByUsernameAsync(string prmUsername);
        Task<Employee> GetEmployeeByIdAsync(int prmId);
        Task<Employee> GetEmployeeByUsernameAsync(string prmUsername);
        Task<IEnumerable<Employee>> GetAllAsync();

    }
}