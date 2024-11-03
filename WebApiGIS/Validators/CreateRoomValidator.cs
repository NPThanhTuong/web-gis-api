using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class CreateRoomValidator : AbstractValidator<CreateRoomReq>
    {
        public CreateRoomValidator()
        {
            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(r => r.IsAvailable)
                .NotNull();

            RuleFor(r => r.IsMezzanine)
                .NotNull();

            RuleFor(r => r.Capability)
                .GreaterThan(0);

            RuleFor(r => r.Geom)
                .NotNull()
                .NotEmpty();

            RuleFor(r => r.Descripption)
                .NotNull()
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(r => r.MotelId)
                .GreaterThanOrEqualTo(0);
        }
    }
}
