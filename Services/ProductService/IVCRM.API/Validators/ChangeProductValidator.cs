using FluentValidation;
using IVCRM.BLL.Models.Products;

namespace IVCRM.API.Validators;

public class CreateProductValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(product => product.Name).NotNull().NotEmpty().Length(3, 50);
    }
}
