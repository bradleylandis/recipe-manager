using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace recipemanager.data
{
    public class RecipeContextFactory : IDesignTimeDbContextFactory<RecipeContext>
    {
        public RecipeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecipeContext>();
            //TODO: Move connection string to config
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=recipemanager;User Id=recipemanager;Password=P@ssw0rd;MultipleActiveResultSets=True");

            return new RecipeContext(optionsBuilder.Options);
        }
    }
}