using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipemanager.business;
using recipemanager.web.Models;

namespace recipemanager.web.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly IRepository<Favorite> favoriteRepository;

        public FavoritesController(IRepository<Favorite> favoriteRepository)
        {
            this.favoriteRepository = favoriteRepository;
        }
        
        // GET
        public IActionResult Index()
        {
            //TODO: add paging or infinite scrolling to avoid unbound query
            var favorites = favoriteRepository
                .Read()
                .Include(f => f.Recipe)
                .Where(f => f.UserId == 1) //TODO: Get UserId from authentication
                .Select(f => new RecipeListItemViewModel {Id = f.Recipe.Id, Title = f.Recipe.Title, ImageSource = ImageHelpers.GetImageSource(f.Recipe.Image)});
            
            var favoritesListViewModel = new FavoritesListViewModel{ Recipes = favorites};
            
            return View(favoritesListViewModel);
        }
    }
}