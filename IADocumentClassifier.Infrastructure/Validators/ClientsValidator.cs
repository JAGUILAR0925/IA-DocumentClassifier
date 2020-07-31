
namespace IADocumentClassifier.Infrastructure.Validators
{
    using FluentValidation;
    using IADocumentClassifier.Cors.Entities;

    public class ClientsValidator : AbstractValidator<Clients>
    {
        public ClientsValidator()
        {
            RuleFor(Clients => Clients.Name)
                .MaximumLength(50);

            RuleFor(Clients => Clients.Identification)
               .NotNull();
        }
    }
}
