using FluentValidation;

namespace WebService.Extentions
{
    public static class ValidatorExtentions
    {
        public static IRuleBuilderOptions<T, DateTime?> Utc<T>(this IRuleBuilderOptions<T, DateTime?> ruleBuilder)
        {
            return ruleBuilder.Must(d => d != null && d.Value.Kind == DateTimeKind.Utc);
        }

        public static IRuleBuilderOptions<T, DateTime?> Utc<T>(this IRuleBuilder<T, DateTime?> ruleBuilder)
        {
            return ruleBuilder.Must(d => d != null && d.Value.Kind == DateTimeKind.Utc);
        }
    }
}
