using System.Collections.Generic;

namespace recipemanager.web.Models
{
    public class RecipeDetailViewModel
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        
        public string ImageSource { get; set; }

        public IEnumerable<RecipeDetailIngredientViewModel> Ingredients { get; set; }
        public IEnumerable<RecipeDetailInstructionViewModel> Instructions { get; set; }
    }
}
