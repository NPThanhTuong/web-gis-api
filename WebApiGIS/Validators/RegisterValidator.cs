using FluentValidation;
using WebApiGIS.Dtos.Request;
using WebApiGIS.Utils;

namespace WebApiGIS.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterReq>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(r => r.Phone)
                .NotEmpty()
                .Matches(@"^(?:\+84|0)(?:3|5|7|8|9)\d{8}$");

            RuleFor(r => r.Name)
                .NotEmpty()
                .MaximumLength(ConstConfig.DisplayNameLength);

            RuleFor(r => r.Password)
                .MinimumLength(ConstConfig.MinPasswordLength)
                .MaximumLength(ConstConfig.MaxPasswordLength);
        }
    }
}
