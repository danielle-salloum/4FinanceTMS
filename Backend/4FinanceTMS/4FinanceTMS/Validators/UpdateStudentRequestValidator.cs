using _4FinanceTMS.InputModels;
using FluentValidation;

namespace _4FinanceTMS.Validators
{
    public class UpdateStudentRequestValidator : AbstractValidator<UpdateStudentInputModel>
    {
        public UpdateStudentRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Major).NotEmpty();
        }
    }
}
