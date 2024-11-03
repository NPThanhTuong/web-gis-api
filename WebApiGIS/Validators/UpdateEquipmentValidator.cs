using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class UpdateEquipmentValidator : AbstractValidator<UpdateEquipmentReq>
    {
        public UpdateEquipmentValidator()
        {
            RuleFor(e => e.Name)
                .MaximumLength(ConstConfig.MediumNameLength);

            RuleFor(e => e.Description)
                .MaximumLength(ConstConfig.DescriptionLength);

            RuleFor(e => e.EquipmentTypeId)
                .GreaterThanOrEqualTo(1);

            RuleFor(e => e.RoomId)
                .GreaterThanOrEqualTo(1);
        }
    }
}
