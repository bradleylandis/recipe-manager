using System.Linq;
using recipemanager.business;

namespace recipemanager.data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        RecipeContext context;

        public Repository(RecipeContext context)
        {
            this.context = context;

        }
        public IQueryable<T> Read()
        {
            return context.Set<T>().AsQueryable<T>();
        }
    }
}