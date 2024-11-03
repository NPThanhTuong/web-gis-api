using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class LoginValidator : AbstractValidator<LoginReq>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(l => l.Password)
                .NotEmpty()
                .MinimumLength(ConstConfig.MinPasswordLength)
                .MaximumLength(ConstConfig.MaxPasswordLength);
        }
    }
}
