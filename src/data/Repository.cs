using System.Linq;
using System.Threading.Tasks;
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

        public async Task Create(T entity)
        {

            context.Set<T>().Attach(entity);

            await context.SaveChangesAsync();
        }
    }
}