using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recipemanager.business;
using recipemanager.web.Models;

namespace recipemanager.web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRepository<Recipe> recipeRepository;

        public RecipesController(IRepository<Recipe> recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public IActionResult Index([FromQuery] string filter)
        {
            var query = recipeRepository.Read();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(r => r.Title.Contains(filter));
            }

            //TODO: use automapper projections
            //TODO: implement paging or infinite scrolling instead of just taking top 10
            var recipeListItems = query.Take(10).Select(r => new RecipeListItemViewModel { Id = r.Id, Title = r.Title, ImageSource = ImageHelpers.GetImageSource(r.Image) });

            return View(new RecipeListViewModel { Filter = filter, Recipes = recipeListItems });
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
                Instructions = model.Instructions.Select(i => new RecipeDetailInstructionViewModel { Description = i.Description }),
                ImageSource = ImageHelpers.GetImageSource(model.Image)
            };

            return View(viewModel);
        }

        public IActionResult Add()
        {
            return View(new AddNewRecipeViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddNewRecipeViewModel addNewRecipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addNewRecipeViewModel);
            }

            byte[] bytesInImage = null;
            if (addNewRecipeViewModel.Image != null)
            {
                await using var ms = new MemoryStream();
                await addNewRecipeViewModel.Image.CopyToAsync(ms);
                bytesInImage = ms.ToArray();
            }

            //Todo: use automapper
            var model = new Recipe
            {
                Title = addNewRecipeViewModel.Title,
                Comment = addNewRecipeViewModel.Comment,
                Instructions = addNewRecipeViewModel.Instructions.Select(i => new Instruction{Description = i.Description}).ToList(),
                Ingredients = addNewRecipeViewModel.Ingredients.Select(i => new Ingredient{Measurement = i.Measurement, Name = i.Name}).ToList(),
                Image = bytesInImage
            };

            await recipeRepository.Create(model);

            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
