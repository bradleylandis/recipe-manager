using System.Collections.Generic;

namespace recipemanager.web.Models
{
    public class FavoritesListViewModel
    {
        public IEnumerable<RecipeListItemViewModel> Recipes { get; set; }
    }
}