using FluentValidation;
using WebService.ViewModels.Request;

namespace WebService.Validators
{
    public class CreateMessageValidator : AbstractValidator<CreateMessageDto>
    {
        public CreateMessageValidator() 
        {
            RuleFor(m => m.Text).NotEmpty().MaximumLength(128);
            RuleFor(m => m.Number).GreaterThan(0);
        }
    }
}
