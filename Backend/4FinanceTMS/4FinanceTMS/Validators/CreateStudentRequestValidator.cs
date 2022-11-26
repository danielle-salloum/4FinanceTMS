using _4FinanceTMS.InputModels;
using FluentValidation;

namespace _4FinanceTMS.Validators
{
    public class CreateStudentRequestValidator : AbstractValidator <CreateStudentInputModel>
    {
        public CreateStudentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Major).NotEmpty();
        }
    }
}
