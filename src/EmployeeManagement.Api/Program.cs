var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApplicationServices();

builder.Services.AddSqlRepositories();
//builder.Services.AddInMemoryRepositories();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AnyOrigin", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
    });
});

var app = builder.Build();

app.UsePathBase(new PathString("/api"));
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AnyOrigin");


app.UseEmployeeEndpoints();
app.UseReportEndpoints();
app.UseTaskEndpoints();

app.UseHttpsRedirection();

app.Run();