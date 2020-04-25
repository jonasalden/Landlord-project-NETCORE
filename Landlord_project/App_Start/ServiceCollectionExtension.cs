using FluentValidation;
using Landlord_project.Models;
using Landlord_project.Models.Validators;
using Landlord_project.Repositories;
using Landlord_project.Services;
using Landlord_project.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Landlord_project.App_Start
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Singleton Services
            #endregion

            #region Scoped Services
            #endregion

            #region Transient Services
            services.AddTransient<IValidator<ReportModel>, ReportValidator>();
            services.AddTransient<IValidator<IFormFile>, FileValidator>();

            services.AddTransient<IPictureService, PictureService>();

            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion
        }
    }
}
