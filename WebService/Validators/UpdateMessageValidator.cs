using FluentValidation;
using WebService.ViewModels.Request;

namespace WebService.Validators
{
    public class UpdateMessageValidator : AbstractValidator<UpdateMessageDto>
    {
        public UpdateMessageValidator() 
        {
            RuleFor(m => m.Text).NotEmpty().MaximumLength(128);
        }
    }
}
