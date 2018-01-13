namespace NewspaperSystem.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models.Materials;
    using Models;

    public class NewspaperSystemDbContext : IdentityDbContext<User>
    {
        public NewspaperSystemDbContext(DbContextOptions<NewspaperSystemDbContext> options)
            : base(options)
        {
        }

        // Materials
        public DbSet<Foil> Foils { get; set; }

        public DbSet<BlackInk> BlackInks { get; set; }

        public DbSet<ColorInk> ColorInks { get; set; }

        public DbSet<Plate> Plates { get; set; }

        public DbSet<BlindPlate> BlindPlates { get; set; }

        public DbSet<PlateDeveloper> PlateDevelopers { get; set; }

        public DbSet<Tape> Tapes { get; set; }

        public DbSet<Wischwasser> Wischwassers { get; set; }

        public DbSet<Paper> Papers { get; set; }

        public DbSet<PaperType> PaperTypes { get; set; }


        // Other tables
        public DbSet<Client> Clients { get; set; }

        public DbSet<Component> Components { get; set; }

        public DbSet<MachineData> MachineDatas { get; set; }

        public DbSet<MaterialConsumption> MaterialConsumptions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderCalc> OrderCalcs { get; set; }

        public DbSet<PaperWaste> PaperWastes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ServicePrice> ServicePrices { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<WebSize> WebSizes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Town>()
                .HasMany(t => t.Clients)
                .WithOne(c => c.Town)
                .HasForeignKey(c => c.TownId);

            builder
                .Entity<Client>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .HasForeignKey(o => o.ClientId);

            builder
                .Entity<Product>()
                .HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId);

            builder
                .Entity<OrderCalc>()
                .HasOne(oc => oc.Order)
                .WithOne(o => o.OrderCalc)
                .HasForeignKey<OrderCalc>(o => o.OrderId);

            builder
                .Entity<Order>()
                .HasOne(o => o.OrderCalc)
                .WithOne(oc => oc.Order)
                .HasForeignKey<Order>(o => o.OrderCalcId);

            builder
                .Entity<Order>()
                .HasOne(o => o.PaperType)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PaperTypeId);

            builder
                .Entity<Paper>()
                .HasOne(p => p.PaperType)
                .WithMany(pt => pt.PaperPrices)
                .HasForeignKey(p => p.PaperTypeId);

            builder
                .Entity<Order>()
                .HasMany(o => o.Components)
                .WithOne(c => c.Order)
                .HasForeignKey(c => c.OrderId);

            builder
                .Entity<Component>()
                .HasOne(c => c.MachineData)
                .WithMany(md => md.Components)
                .HasForeignKey(c => c.MachineDataId);

            builder
                .Entity<MachineData>()
                .HasOne(md => md.Web1)
                .WithMany(ws => ws.MachineDatas1)
                .HasForeignKey(md => md.Web1Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<MachineData>()
                .HasOne(md => md.Web2)
                .WithMany(ws => ws.MachineDatas2)
                .HasForeignKey(md => md.Web2Id)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
