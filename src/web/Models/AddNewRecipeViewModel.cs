using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace recipemanager.web.Models
{
    public class AddNewRecipeViewModel
    {
        public string Title { get; set; }

        public string Comment { get; set; }
        
        public IFormFile Image { get; set; }

        public List<AddNewRecipeInstructionViewModel> Instructions { get; set; } =
            new() {new(), new ()};
        
        public List<AddNewRecipeIngredientViewModel> Ingredients { get; set; } =
            new() {new(), new ()};
    }
}