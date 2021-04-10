using FluentValidation;
using WebAPiNetcore5.Controllers.V1.Request;

namespace WebAPiNetcore5.Validators
{
    public class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
    {
        public CreateTodoRequestValidator()
        {

            RuleFor(x => x.TodoName)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
        }
    }
}
