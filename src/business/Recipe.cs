using System.Collections.Generic;

namespace recipemanager.business
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Comment { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public ICollection<Instruction> Instructions { get; set; } = new List<Instruction>();
    }
}