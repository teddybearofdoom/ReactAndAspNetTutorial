using FluentValidation;

namespace Admin.Signup
{
    public class Request
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


    }

    public class Validator : Validator<Request>
    {
        public Validator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Name is Required")
                .MinimumLength(3).WithMessage("Name is too short")
                .MaximumLength(25).WithMessage("Name is too long");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Name is Required")
                .MinimumLength(3).WithMessage("Name is too short")
                .MaximumLength(25).WithMessage("Name is too long");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email Address is Required")
                .EmailAddress().WithMessage("The format of your email address is wrong");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is Required")
                .MinimumLength(3).WithMessage("Username is too short")
                .MaximumLength(15).WithMessage("Username is too long");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Password is Required")
                .MinimumLength(8).WithMessage("Password is too short")
                .MaximumLength(25).WithMessage("Password is too long");


        }
    }

    public class Response
    {
        public string Message { get; set; } = string.Empty; 
    }
}