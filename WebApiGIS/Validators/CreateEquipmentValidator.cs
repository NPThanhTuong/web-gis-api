using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class CreateEquipmentValidator : AbstractValidator<CreateEquipmentReq>
    {
        public CreateEquipmentValidator()
        {
            RuleFor(e => e.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(e => e.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(e => e.EquipmentTypeId)
                .GreaterThanOrEqualTo(1);

            RuleFor(e => e.RoomId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
