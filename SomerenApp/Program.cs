using SomerenApp.Repositories;

namespace SomerenApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<ILecturersRepository, DbLecturersRepository>();
            builder.Services.AddSingleton<IStudentsRepository, DbStudentsRepository>();
            builder.Services.AddSingleton<IRoomsRepository, DbRoomsRepository>();
            builder.Services.AddSingleton<IDrinkOrdersRepository, DbDrinkOrdersRepository>();
            builder.Services.AddSingleton<IActivitiesRepository, DbActivitiesRepository>();
            builder.Services.AddSingleton<IParticipantsRepository, DbParticipantsRepository>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
