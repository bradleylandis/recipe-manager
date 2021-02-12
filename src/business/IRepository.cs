using System.Linq;
using System.Threading.Tasks;

namespace recipemanager.business
{
    public interface IRepository<T>
    {
        IQueryable<T> Read();
        Task Create(T entity);
    }
}