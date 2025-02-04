using FluentValidation;
using WebService.ViewModels.Request;

namespace WebService.Validators
{
    public class MessageFilterValidator : AbstractValidator<MessageFilter>
    {
        public MessageFilterValidator() 
        {
            RuleFor(f => f.StartTime).NotEmpty();
            RuleFor(f => f.EndTime).NotEmpty().GreaterThanOrEqualTo(f => f.StartTime);
        }
    }
}
