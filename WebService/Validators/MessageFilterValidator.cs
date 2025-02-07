using FluentValidation;
using WebService.Extentions;
using WebService.ViewModels.Request;

namespace WebService.Validators
{
    public class MessageFilterValidator : AbstractValidator<MessageFilter>
    {
        public MessageFilterValidator() 
        {
            RuleFor(f => f.StartTime).Utc().When(s => s.StartTime != null).WithMessage("Start time must be in UTC");
            
            RuleFor(f => f.EndTime).Utc().When(f => f.EndTime != null).WithMessage("End time must be in UTC")
                                   .GreaterThanOrEqualTo(f => f.StartTime).When(f => f.StartTime != null && f.EndTime != null);
        }
    }
}
