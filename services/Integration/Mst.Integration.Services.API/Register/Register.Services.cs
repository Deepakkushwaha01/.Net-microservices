using External.Core.Persistence.Common.UnitOfWork;
using Mst.Common.Packages.Upload;
using Mst.Core.Contracts.Common.UnitOfWork;
using Mst.Integration.Core.Persistence.CustomerReview.Repositories;

namespace External.API.Registers
{
    public static partial class Register
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            #region Services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Upload
            services.AddScoped<IFileUploadService, FileUploadService>();
            #endregion

            #region Repositories
            services.AddScoped<ICustomerReviewRepo, CustomerReviewRepo>();
            #endregion




            return services;
        }
    }
}