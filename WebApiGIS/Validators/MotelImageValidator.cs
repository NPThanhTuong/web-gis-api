using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class MotelImageValidator : AbstractValidator<MotelImageReq>
    {
        public MotelImageValidator()
        {
            RuleFor(mi => mi.Path)
                .MaximumLength(ConstConfig.ImagePathLength);
        }
    }
}
