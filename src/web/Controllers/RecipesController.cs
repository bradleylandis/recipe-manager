using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using recipemanager.business;
using recipemanager.web.Models;

namespace recipemanager.web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ILogger<RecipesController> logger;
        private readonly IRepository<Recipe> recipeRepository;

        public RecipesController(ILogger<RecipesController> logger, IRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            //TODO: use automapper projections
            var viewModels = recipeRepository.Read().Select(r => new RecipeListItem { Id = r.Id, Title = r.Title });
            return View(viewModels);
        }

        public IActionResult View(int id)
        {
            var model = recipeRepository.Read().Include(r => r.Ingredients).Include(r => r.Instructions).FirstOrDefault(r => r.Id == id);

            if (model == null)
            {
                return NotFound();
            }

            //TODO: use automapper projections
            var viewModel = new RecipeDetailViewModel
            {
                Title = model.Title,
                Comment = model.Comment,
                Ingredients = model.Ingredients.Select(i => new RecipeDetailIngredientViewModel { Name = i.Name, Measurement = i.Measurement }),
                Instructions = model.Instructions.Select(i => new RecipeDetailInstructionViewModel { Description = i.Description })
            };


            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
