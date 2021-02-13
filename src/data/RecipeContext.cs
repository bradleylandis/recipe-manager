using Microsoft.EntityFrameworkCore;
using recipemanager.business;

namespace recipemanager.data
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
