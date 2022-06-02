namespace EmployeeManagement.Api
{
    public static class ConfigureServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IWorkTaskService, WorkTaskService>();
            services.AddScoped<IReportService, ReportService>();
        }

        public static void AddSqlRepositories(this IServiceCollection services)
        {
            services.AddSingleton<ISqlDataAccess, DapperDataAccess>();
            services.AddSingleton<IEmployeeRepository, Infrastructure.Repositories.Sql.EmployeeRepoSql>();
            services.AddSingleton<IWorkTaskRepository, Infrastructure.Repositories.Sql.WorkTaskRepoSql>();
            services.AddSingleton<IReportRepository, Infrastructure.Repositories.Sql.ReportRepoSql>();
        }

        public static void AddInMemoryRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, Infrastructure.Repositories.InMemory.EmployeeRepoInMemory>();
            services.AddSingleton<IWorkTaskRepository, Infrastructure.Repositories.InMemory.WorkTaskRepoInMemory>();
            services.AddSingleton<IReportRepository, Infrastructure.Repositories.InMemory.ReportRepoInMemory>();
        }
    }
}
