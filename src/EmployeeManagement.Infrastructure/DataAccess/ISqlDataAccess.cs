﻿namespace EmployeeManagement.Infrastructure.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
        Task<int> InsertDataAndGetKeyAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}