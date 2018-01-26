using Smarket.API.Domain.Interfaces.IContext;
namespace Smarket.API.Model.Context
{
    using Smarket.API.Model.EntityConfig;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public partial class SmarketContext : DbContext, IDbContext
    {
        public SmarketContext()
            : base("name=SmarketContext")
        {
            Database.SetInitializer<SmarketContext>(null);

        }

        public virtual IDbSet<Consumers> Consumers   { get; set; }
        public virtual IDbSet<Logs>      Logs        { get; set; }
        public virtual IDbSet<Phones>    Phones      { get; set; }
        public virtual IDbSet<TypePhone> TypePhone   { get; set; }
        public virtual IDbSet<TypeUsers> TypeUsers   { get; set; }
        public virtual IDbSet<Users>     Users       { get; set; }
        //public virtual DbSet<ConsumersPhones> ConsumersPhones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(el => el.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(el => el.HasMaxLength(255));

            modelBuilder.Configurations.Add(new UsersConfig());
            modelBuilder.Configurations.Add(new TypeUsersConfig());
            modelBuilder.Configurations.Add(new LogsConfig());
            modelBuilder.Configurations.Add(new PhonesConfig());
            modelBuilder.Configurations.Add(new TypePhoneConfig());
            modelBuilder.Configurations.Add(new ConsumersConfig());
        }
    }
}
