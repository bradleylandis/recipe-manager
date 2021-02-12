using System.Collections.Generic;

namespace recipemanager.web.Models
{
    public class RecipeListViewModel
    {
        public string Filter { get; set; }
        public IEnumerable<RecipeListItemViewModel> Recipes { get; set; }
    }
}