using FluentValidation;

namespace OpenMenu.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    public CreateRestaurantCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Restoran adı boş olamaz.")
            .MaximumLength(200).WithMessage("Restoran adı 200 karakterden fazla olamaz.");

        RuleFor(x => x.Phone)
            .MaximumLength(20).WithMessage("Telefon numarası 20 karakterden fazla olamaz.")
            .When(x => x.Phone is not null);
    }
}
