using _4FinanceTMS.InputModels;
using FluentValidation;

namespace _4FinanceTMS.Validators
{
    public class CreateCourseRequestValidator : AbstractValidator<CreateCourseInputModel>
    {
        public CreateCourseRequestValidator()
        {

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CreditNumber).NotEmpty();
        }
    }
}
