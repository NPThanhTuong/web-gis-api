using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class UpdateMotelValidator : AbstractValidator<UpdateMotelReq>
    {
        public UpdateMotelValidator()
        {
            RuleFor(m => m.Name)
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(m => m.Description)
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(m => m.UserId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
