
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training_Center.Customized_result;
using TrainingSystem.abstraction.ICentreService;
using TrainingSystem.abstraction.IServiceProviderPattern;
using TrainingSystem.abstraction.IServiceProviderPattern.ServiceProviderPattern;
using TrainingSystem.data.Contracts.IUOWPattern;
using TrainingSystem.Persistance.Context;
using TrainingSystem.Persistance.UOWPattern;
using TrainingSystem.Service.CenterService;
using TrainingSystem.Service.MappingProfile;
using TrainingSystem.Shared.ErrorToReturn;
using static Training_Center.Customized_result.CustomExceptionMiddleWare;

namespace Training_Center
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.

            builder.Services.AddControllers();
            //DB Connection
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            { options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
            builder.Services.AddScoped<IUOW, UOW>();
            builder.Services.AddScoped<IServicemanager, Servicemanager>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new MainProfile());

            });
            // Custom response
            builder.Services.Configure<ApiBehaviorOptions>(
                                    (options) => options.InvalidModelStateResponseFactory = (context) =>
                                    {
                                        var errors = context.ModelState.Where(e => e.Value.Errors.Any())
                                        .Select(e => new ValidationError()
                                        {
                                            feild = e.Key,
                                            errors = e.Value.Errors.Select(e => e.ErrorMessage)
                                        });

                                        var Response = new ValidationErrorToReturn()
                                        {
                                            ValidationError = errors
                                        };
                                        return new BadRequestObjectResult(Response);
                                    }


                                );

            //swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "Training Center API",
                    Version = "v1"
                });
            });
            var app = builder.Build();
           
            //  Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Training Center API v1");
                c.RoutePrefix = "swagger";
            });
            app.UseMiddleware<CustomExceptionMiddleWare>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
