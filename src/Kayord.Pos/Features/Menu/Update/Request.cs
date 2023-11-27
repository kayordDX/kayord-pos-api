using FluentValidation;

namespace Kayord.Pos.Features.Menu.Update
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(v => v.Id).GreaterThan(0).WithMessage("MenuId must be greater than 0");
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is required");

        }
    }
}