//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//namespace E_Commerce.Data
//{
//    public static class Initializer
//    {
//        public static void AddDAL(this IServiceCollection services, IConfiguration configuration)
//        {
//            var connectionString = configuration.GetConnectionString("Default");
//            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
//            //services.AddScoped<IUnitOfWork, EFUnitOfWork>();
//        }
//    }
//}
