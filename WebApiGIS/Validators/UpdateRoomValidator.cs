using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class UpdateRoomValidator : AbstractValidator<UpdateRoomReq>
    {
        public UpdateRoomValidator()
        {
            RuleFor(r => r.Price)
               .GreaterThanOrEqualTo(0);

            RuleFor(r => r.Capability)
                .GreaterThan(0);

            RuleFor(r => r.Descripption)
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(r => r.MotelId)
                .GreaterThanOrEqualTo(0);
        }
    }
}
