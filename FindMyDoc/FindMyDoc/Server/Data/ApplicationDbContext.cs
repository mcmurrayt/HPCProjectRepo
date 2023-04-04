using Duende.IdentityServer.EntityFramework.Options;
using FindMyDoc.Server.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FindMyDoc.Shared;

namespace FindMyDoc.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions){}

        public DbSet<Provider> Providers => Set<Provider>();
        public DbSet<FipsState> FipsStates => Set<FipsState>();
        public DbSet<FipsCounty> FipsCounties => Set<FipsCounty>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FipsState>().ToTable("Fips_State");
            modelBuilder.Entity<FipsState>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<FipsState>().Property(p => p.StateFIPSCode).HasColumnName("State_Fips_Code");
            modelBuilder.Entity<FipsState>().Property(p => p.StateName).HasColumnName("State_Name");

            modelBuilder.Entity<FipsCounty>().ToTable("Fips_County");
            modelBuilder.Entity<FipsCounty>().Property(p => p.Id).HasColumnName("Id");
            modelBuilder.Entity<FipsCounty>().Property(p => p.CountyFIPSCode).HasColumnName("County_Fips_Code");
            modelBuilder.Entity<FipsCounty>().Property(p => p.CountyName).HasColumnName("County_Name");
            modelBuilder.Entity<FipsCounty>().Property(p => p.FipsStateId).HasColumnName("Fips_State_Id");

            /*modelBuilder.Entity<FipsState>()
            .HasOne(s => s.County)
            .WithMany()
            .HasForeignKey(c => c.Id);*/
        }
    }
}