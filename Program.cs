using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NomadBuddy00.Data;
using NomadBuddy00.Models;
using NomadBuddy00.Repositories;
using NomadBuddy00.Services;

namespace NomadBuddy00
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
              opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
              );

            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

            //Repository
            builder.Services.AddScoped<INomadRepository, NomadRepository>();
            builder.Services.AddScoped<ITravelerQuizRepository, TravelerQuizRepository>();
            builder.Services.AddScoped<INomadPreferenceRepository, NomadPreferenceRepository>();
            builder.Services.AddScoped<IVisaPolicyRepository, VisaPolicyRepository>();
            builder.Services.AddScoped<ICountryRepository, CountryRepository>();
            builder.Services.AddScoped<INationalityRepository, NationalityRepository>();
            builder.Services.AddScoped<ITripPlanRepository, TripPlanRepository>();
            builder.Services.AddScoped<ICityExtendedRatingRepository, CityExtendedRatingRepository>();
            builder.Services.AddScoped<ICityRecommendationRepository, CityRecommendationRepository>();
            builder.Services.AddScoped<IFriendsProfileRepository, FriendsProfileRepository>();
            builder.Services.AddScoped<INomadLikeRepository, NomadLikeRepository>();
            builder.Services.AddScoped<INomadMatchRepository, NomadMatchRepository>();
            builder.Services.AddScoped<ICollabSpaceRepository, CollabSpaceRepository>();
            builder.Services.AddScoped<ITripPinRepository, TripPinRepository>();
            builder.Services.AddScoped<IRepository<Activity>, ActivityRepository>();
            builder.Services.AddScoped<IActivityReservationRepository, ActivityReservationRepository>();

            //Service
            builder.Services.AddScoped<ICityOverallRatingService, CityOverallRatingService>();

            builder.Services.AddLogging();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {

                    Console.WriteLine("Starting nationalities seeding...");
                    NationalitySeeder.SeedNationalitiesAsync(services).Wait();
                    Console.WriteLine("Nationalities seeding completed.");

                    Console.WriteLine("Starting countries seeding...");
                    CountrySeeder.SeedCountriesAsync(services).Wait();
                    Console.WriteLine("Countries seeding completed.");
                    
                    Console.WriteLine("Starting visa policy seeding...");
                    VisaPolicySeeder.SeedVisaPoliciesAsync(services).Wait();
                    Console.WriteLine("Visa policy seeding completed.");

                    Console.WriteLine("Starting role seeding...");
                    RoleSeeder.SeedRolesAsync(services).Wait();
                    Console.WriteLine("Role seeding completed.");

                    Console.WriteLine("Starting user seeding...");
                    UserSeeder.InitializeUsersAsync(services).Wait();
                    Console.WriteLine("User seeding completed.");
                    
                    Console.WriteLine("Starting interest seeding...");
                    InterestSeeder.SeedInterestsAsync(services).Wait();
                    Console.WriteLine("Interest seeding completed.");
                                        
                    Console.WriteLine("Starting traveler type seeding...");
                    TravelerTypeSeeder.SeedTravelerTypesAsync(services).Wait();
                    Console.WriteLine("Traveler type seeding completed.");
                    
                    Console.WriteLine("Starting traveler preference type seeding...");
                    TravelerPreferenceSeeder.SeedTravelerPreferencesAsync(services).Wait();
                    Console.WriteLine("Traveler preference seeding completed.");

                    Console.WriteLine("Starting activity seeding...");
                    ActivitySeeder.SeedActivitiesAsync(services).Wait();
                    Console.WriteLine("Activity seeding completed.");
                    
                    Console.WriteLine("Starting cities seeding...");
                    CitySeeder.SeedCitiesAsync(services).Wait();
                    Console.WriteLine("Cities seeding completed.");
                    
                    Console.WriteLine("Starting city tags seeding...");
                    CityTagSeeder.SeedCityTagsAsync(services).Wait();
                    Console.WriteLine("City tags seeding completed.");

                    Console.WriteLine("Starting trip plan seeding...");
                    TripPlanSeeder.SeedTripPlansAsync(services).Wait();
                    Console.WriteLine("Trip plan seeding completed.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($" Error during seeding: {ex.Message}");
                }
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                //pattern: "{controller=Home}/{action=Index}/{id?}")
                pattern: "{controller=Activity}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
