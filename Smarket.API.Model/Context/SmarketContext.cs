using Smarket.API.Domain.Interfaces.IContext;

namespace Smarket.API.Model.Context
{
    using System.Data.Entity;

    public partial class SmarketContext : DbContext, IDbContext
    {
        public SmarketContext()
            : base("name=SmarketContext")
        {
        }

        public virtual DbSet<Consumers> Consumers   { get; set; }
        public virtual DbSet<Logs>      Logs        { get; set; }
        public virtual DbSet<Phones>    Phones      { get; set; }
        public virtual DbSet<TypePhone> TypePhone   { get; set; }
        public virtual DbSet<TypeUsers> TypeUsers   { get; set; }
        public virtual DbSet<Users>     Users       { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumers>()
                .Property(e => e.Avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Consumers>()
                .HasMany(e => e.Phones)
                .WithMany(e => e.Consumers)
                .Map(m => m.ToTable("ConsumersPhones").MapLeftKey("UserId").MapRightKey("PhoneId"));

            modelBuilder.Entity<Logs>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<TypePhone>()
                .HasMany(e => e.Phones)
                .WithRequired(e => e.TypePhone)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypeUsers>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.TypeUsers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasOptional(e => e.Consumers)
                .WithRequired(e => e.Users);
        }
    }
}
