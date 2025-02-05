using FluentValidation;
using WebService.ViewModels.Request;

namespace WebService.Validators
{
    public class MessageFilterValidator : AbstractValidator<MessageFilter>
    {
        public MessageFilterValidator() 
        {
            RuleFor(f => f.StartTime);
            RuleFor(f => f.EndTime).GreaterThanOrEqualTo(f => f.StartTime).When(f => f.StartTime != null && f.EndTime != null);
        }
    }
}
