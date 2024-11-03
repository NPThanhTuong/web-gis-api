using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class CreateMotelValidator : AbstractValidator<CreateMotelReq>
    {
        public CreateMotelValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(m => m.Description)
                .NotEmpty()
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(m => m.Geom)
                .NotEmpty();

            RuleFor(m => m.UserId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
