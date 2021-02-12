using System.Linq;

namespace recipemanager.business
{
    public interface IRepository<T>
    {
        IQueryable<T> Read();
    }
}