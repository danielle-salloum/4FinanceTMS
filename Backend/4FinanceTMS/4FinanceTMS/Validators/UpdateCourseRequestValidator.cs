using _4FinanceTMS.InputModels;
using FluentValidation;

namespace _4FinanceTMS.Validators
{
    public class UpdateCourseRequestValidator : AbstractValidator<UpdateCourseInputModel>
    {
        public UpdateCourseRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CreditNumber).NotEmpty();
        }
    }
}
