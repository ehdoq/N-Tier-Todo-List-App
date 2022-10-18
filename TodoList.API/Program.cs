using TodoList.Extension.Extensions;
using TodoList.Extension.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureModelStateInvalidFilter();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureAutofac(builder);
builder.Services.ConfigureNotFoundFilter();
builder.Services.ConfigureAuthentication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (true) //Swagger'ýn sürekli görünmesi için
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API v1"));
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseCustomException();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
