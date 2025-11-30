using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;
using System.Collections.Generic;
using NomadBuddy00.Models;

namespace NomadBuddy00.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Nomad> Nomads { get; set; }
        public DbSet<NomadInterest> NomadInterests { get; set; }
        public DbSet<TravelerType> TravelerTypes { get; set; }
        public DbSet<TravelerQuestion> TravelerQuestions { get; set; }
        public DbSet<TravelerAnswer> TravelerAnswers { get; set; }
        public DbSet<TravelerTypeScore> TravelerTypeScores { get; set; }
        public DbSet<TravelerPreference> TravelerPreferences { get; set; }
        public DbSet<NomadPreference> NomadPreferences { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<VisaPolicy> VisaPolicies { get; set; }
        public DbSet<TripPlan> TripPlans { get; set; }
        public DbSet<TripStop> TripStops { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityOverallRating> CityOverallRatings { get; set; }
        public DbSet<CitySafetyRating> CitySafetyRatings { get; set; }
        public DbSet<CityCostOfLivingRating> CityCostOfLivingRatings { get; set; }
        public DbSet<CityHealthcareRating> CityHealthcareRatings { get; set; }
        public DbSet<CityTransportRating> CityTransportRatings { get; set; }
        public DbSet<CityEntertainmentRating> CityEntertainmentRatings { get; set; }
        public DbSet<CityTag> CityTags { get; set; }
        public DbSet<CityTagVote> CityTagVotes { get; set; }
        public DbSet<FriendsProfile> FriendsProfiles { get; set; }
        public DbSet<NetworkingProfile> NetworkingProfiles { get; set; }
        public DbSet<NomadLike> NomadLikes { get; set; }
        public DbSet<NomadMatch> NomadMatches { get; set; }
        public DbSet<NomadCompatibilityScore> NomadCompatibilityScores { get; set; }
        public DbSet<CollabSpace> CollabSpaces { get; set; }
        public DbSet<CollabIdea> CollabIdeas { get; set; }
        public DbSet<TripPin> TripPins { get; set; }

        //buddies 
        public DbSet<Buddy> Buddies { get; set; }
        public DbSet<BuddySupport> BuddySupports { get; set; }
        public DbSet<BuddySupportAssignment> BuddySupportAssignments { get; set; }
        public DbSet<BuddySupportRequest> BuddySupportRequests { get; set; }
        public DbSet<BuddySupportSession> BuddySupportSessions { get; set; }
        public DbSet<BuddySupportRating> BuddySupportRatings { get; set; }
        
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityReservation> ActivityReservations { get; set; } 
        public DbSet<ActivityAssignment> ActivityAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            // Define Table Per Type (TPT) Strategy
            /*            modelBuilder.Entity<Nomad>().ToTable("Nomads");
                        modelBuilder.Entity<Buddy>().ToTable("Buddies");*/

            // Relacja jeden-do-jeden ApplicationUser <-> Nomad
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Nomad)
                .WithOne(n => n.User)
                .HasForeignKey<Nomad>(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja jeden-do-jeden ApplicationUser <-> Buddy
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Buddy)
                .WithOne(b => b.User)
                .HasForeignKey<Buddy>(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Country)
                .WithMany()
                .HasForeignKey(u => u.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Nomad>()
                .HasMany(n => n.Interests)
                .WithOne(i => i.Nomad)
                .HasForeignKey(i => i.NomadId);

/*            modelBuilder.Entity<TravelerQuestion>()
                .HasOne(q => q.TravelerType)
                .WithMany()
                .HasForeignKey(q => q.TravelerTypeId)
                .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Entity<TravelerQuestion>()
                .HasOne(q => q.TravelerType)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TravelerTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TravelerType>()
                .HasMany(tt => tt.SuggestedPreferences)
                .WithMany(tp => tp.SuggestedForTypes)
                .UsingEntity(j => j.ToTable("TravelerTypePreference"));

            modelBuilder.Entity<CityOverallRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🔐 CitySafetyRating: many ratings per city & nomad
            modelBuilder.Entity<CitySafetyRating>()
                .HasOne(r => r.City)
                .WithMany(c => c.SafetyRatings)
                .HasForeignKey(r => r.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CitySafetyRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            // 💸 CityCostOfLivingRating
            modelBuilder.Entity<CityCostOfLivingRating>()
                .HasOne(r => r.City)
                .WithMany(c => c.CostRatings)
                .HasForeignKey(r => r.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityCostOfLivingRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            // 🏥 CityHealthcareRating
            modelBuilder.Entity<CityHealthcareRating>()
                .HasOne(r => r.City)
                .WithMany(c => c.HealthcareRatings)
                .HasForeignKey(r => r.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityHealthcareRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CityEntertainmentRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CityTransportRating>()
                .HasOne(r => r.Nomad)
                .WithMany()
                .HasForeignKey(r => r.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CityTagVote>()
                .HasOne(v => v.Nomad)
                .WithMany()
                .HasForeignKey(v => v.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relacja 1:1 Nomad <-> FriendsProfile
            modelBuilder.Entity<Nomad>()
                .HasOne(n => n.FriendsProfile)
                .WithOne(fp => fp.Nomad)
                .HasForeignKey<FriendsProfile>(fp => fp.NomadId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacja 1:1 Nomad <-> NetworkingProfile
            modelBuilder.Entity<Nomad>()
                .HasOne(n => n.NetworkingProfile)
                .WithOne(np => np.Nomad)
                .HasForeignKey<NetworkingProfile>(np => np.NomadId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<NomadCompatibilityScore>()
                .HasOne(n => n.Nomad)
                .WithMany()
                .HasForeignKey(n => n.NomadId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NomadCompatibilityScore>()
                .HasOne(n => n.TargetNomad)
                .WithMany()
                .HasForeignKey(n => n.TargetNomadId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NomadLike>()
                .HasOne(l => l.Liker)
                .WithMany()
                .HasForeignKey(l => l.LikerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NomadLike>()
                .HasOne(l => l.Target)
                .WithMany()
                .HasForeignKey(l => l.TargetId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NomadMatch>()
                .HasOne(m => m.Nomad1)
                .WithMany()
                .HasForeignKey(m => m.Nomad1Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<NomadMatch>()
                .HasOne(m => m.Nomad2)
                .WithMany()
                .HasForeignKey(m => m.Nomad2Id)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TripPin>()
                .HasOne(tp => tp.NomadMatch)
                .WithMany() // jeśli NomadMatch nie ma ICollection<TripPin>
                .HasForeignKey(tp => tp.NomadMatchId)
                .OnDelete(DeleteBehavior.Cascade); // lub NoAction jeśli nie chcesz kaskadowego usuwania

            modelBuilder.Entity<TripStop>()
                .HasOne(ts => ts.TripPlan)
                .WithMany(tp => tp.TripStops)
                .HasForeignKey(ts => ts.TripPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuddySupportAssignment>()
                .HasOne(a => a.BuddySupport)
                .WithMany(s => s.BuddySupportAssignments)
                .HasForeignKey(a => a.BuddySupportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuddySupportAssignment>()
                .HasOne(a => a.Buddy)
                .WithMany(b => b.BuddySupportAssignments)
                .HasForeignKey(a => a.BuddyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuddySupport>()
                .HasOne(s => s.City)
                .WithMany()
                .HasForeignKey(s => s.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuddySupport>()
                .HasOne(s => s.Country)
                .WithMany()
                .HasForeignKey(s => s.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Restrict nie pozwoli na skasowanie request jest istnieje powiazane bssession
            modelBuilder.Entity<BuddySupportSession>()
                .HasOne(s => s.BuddySupportRequest)
                .WithMany()
                .HasForeignKey(s => s.BuddySupportRequestId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BuddySupportSession>()
                .HasOne(s => s.Nomad)
                .WithMany()
                .HasForeignKey(s => s.NomadId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BuddySupportSession>()
                .HasOne(s => s.Buddy)
                .WithMany()
                .HasForeignKey(s => s.BuddyId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<BuddySupportRating>()
                .HasOne(s => s.BuddySupportSession)
                .WithMany()
                .HasForeignKey(s => s.BuddySupportSessionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<BuddySupportRating>()
                .HasOne(s => s.Nomad)
                .WithMany()
                .HasForeignKey(s => s.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BuddySupportRating>()
                .HasOne(s => s.Buddy)
                .WithMany()
                .HasForeignKey(s => s.BuddyId)
                .OnDelete(DeleteBehavior.Restrict);



            // Many-to-Many: Nomads & Activities via ActivityReservation
            modelBuilder.Entity<ActivityReservation>()
                .HasOne(ar => ar.Activity)
                .WithMany(a => a.Reservations)
                .HasForeignKey(ar => ar.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityReservation>()
                .HasOne(ar => ar.Nomad)
                .WithMany(n => n.Reservations)
                .HasForeignKey(ar => ar.NomadId)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many: Buddies & Activities via ActivityAssignment
            modelBuilder.Entity<ActivityAssignment>()
                .HasOne(aa => aa.Activity)
                .WithMany(a => a.ActivityAssignments)
                .HasForeignKey(aa => aa.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ActivityAssignment>()
                .HasOne(aa => aa.Buddy)
                .WithMany(b => b.ActivityAssignments)
                .HasForeignKey(aa => aa.BuddyId)
                .OnDelete(DeleteBehavior.Restrict);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var decimalProperties = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

                foreach (var property in decimalProperties)
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }

        }
    }
}
