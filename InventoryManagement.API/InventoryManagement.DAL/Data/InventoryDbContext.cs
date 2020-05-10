using InventoryManagement.Domain.Request.Drink;
using InventoryManagement.Domain.Request.Ingredient;
using InventoryManagement.Domain.Request.Type;
using InventoryManagement.Domain.Request.Unit;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.DAL.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
        {

        }

        public virtual DbSet<tblIngredient> Ingredients { get; set; }
        public virtual DbSet<tblDrink> Drinks { get; set; }
        public virtual DbSet<tblType> Types { get; set; }
        public virtual DbSet<tblUnit> Units { get; set; }
    }
}
