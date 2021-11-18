using AutoMapper;
using LearningResourcesApi.Data;
using LearningResourcesApi.MappingProfiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);//kestrel web server 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(pol =>
    {
        pol.AllowAnyHeader();
        pol.AllowAnyMethod();
        pol.AllowAnyOrigin();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LearningResourcesDataContext>(options =>
{
    //conn string to SQL server goes here, cardinal sin to hard code that here
    //for production, put this into configuration
    //@"server=.\sqlexpress;database=learning_dev;integrated security=true"
    options.UseSqlServer(builder.Configuration.GetConnectionString("learning-resources"));
});

var mapperConfiguration = new MapperConfiguration(pol =>
{
    pol.AddProfile<LearningResourcesProfile>();
});

var mapper = mapperConfiguration.CreateMapper();

builder.Services.AddSingleton<IMapper>(mapper);
builder.Services.AddSingleton(mapperConfiguration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
