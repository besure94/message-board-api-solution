using MessageBoardApi.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MessageBoardApiContext>(
                  dbContextOptions => dbContextOptions
                    .UseMySql(
                      builder.Configuration["ConnectionStrings:DefaultConnection"],
                      ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
                    )
                  )
                );

builder.Services.AddApiVersioning(opt =>
                {
                    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
                    opt.AssumeDefaultVersionWhenUnspecified = true;
                    opt.ReportApiVersions = true;
                    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader        ("x-api-version"),
                    new MediaTypeApiVersionReader("x-api-version"));
                });

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
      foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
      {
        options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
          description.GroupName.ToUpperInvariant());
      }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
