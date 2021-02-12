using FluentValidation;
using recipemanager.web.Models;

namespace recipemanager.web
{
    public class AddNewRecipeViewModelValidator : AbstractValidator<AddNewRecipeViewModel>
    {
        public AddNewRecipeViewModelValidator()
        {
            RuleFor(x => x.Title).NotNull().Length(1, 10);
            RuleFor(x => x.Comment).NotNull();
        }
    }
}
