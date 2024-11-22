
using Electrolux.Api.ODataApi;
using Electrolux.Api.ODataApi.Model.Customer;
using Electrolux.Api.ODataApi.Services;
using Electrolux.Api.ODataApi.Services.Interfaces;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<WeatherForecast>("WeatherForecast");
modelBuilder.EntitySet<IndividualCustomer>("IndividualCustomer");



builder.Services.AddTransient<IIndividualCustomerService, IndividualCustomerService>();

builder.Services.AddControllers().AddOData(
    options => options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(null));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
