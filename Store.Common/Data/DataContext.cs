using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Common.Data.Entities;
using System.Linq;

namespace Store.Common.Data
{
	public class DataContext : IdentityDbContext<User>
	{
		public DbSet<Category> Categories { get; set; }

		public DbSet<Subcategory> Subcategories { get; set; }

		public DbSet<Brand> Brands { get; set; }

		public DbSet<Presentation> Presentations { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderDetail> OrderDetails { get; set; }

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var cascadeFKs = modelBuilder.Model
				.G­etEntityTypes()
				.SelectMany(t => t.GetForeignKeys())
				.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
			foreach (var fk in cascadeFKs)
			{
				fk.DeleteBehavior = DeleteBehavior.Restr­ict;
			}

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Product>()
			.HasIndex(t => t.Name)
			.IsUnique();

		}
	}
}
