using Customer.Domain.DTOs;
using FluentValidation;

namespace Customer.API.Filters
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(createCustomerRequest => createCustomerRequest.FirstName).NotEmpty().NotNull().WithMessage("Please specify a first name");
            RuleFor(createCustomerRequest => createCustomerRequest.FirstName).MaximumLength(50).WithMessage("First Name must not exceed 50 characters");

            RuleFor(createCustomerRequest => createCustomerRequest.LastName).NotEmpty().NotNull().WithMessage("Please specify a last name");
            RuleFor(createCustomerRequest => createCustomerRequest.LastName).MaximumLength(50).WithMessage("Last Name must not exceed 50 characters");

            RuleFor(createCustomerRequest => createCustomerRequest.CustomerCode).NotEmpty().NotNull().WithMessage("Please specify a Customer Code");

            RuleFor(createCustomerRequest => createCustomerRequest.PhoneNo).NotEmpty().NotNull().WithMessage("Please specify a phone number");
            RuleFor(createCustomerRequest => createCustomerRequest.PhoneNo).MaximumLength(20).WithMessage("Phone number must not exceed 20 characters");

            RuleFor(createCustomerRequest => createCustomerRequest.HouseAddress).NotEmpty().NotNull().WithMessage("Please specify a house address");
            RuleFor(createCustomerRequest => createCustomerRequest.HouseAddress).MaximumLength(200).WithMessage("House Address must not exceed 200 characters");

            RuleFor(createCustomerRequest => createCustomerRequest.AccountNumber).NotEmpty().NotNull().WithMessage("Please specify an account number");
            RuleFor(createCustomerRequest => createCustomerRequest.AccountNumber).MaximumLength(10).WithMessage("AccountNumber must not exceed 10 characters");

            RuleFor(createCustomerRequest => createCustomerRequest.Email).NotEmpty().NotNull().WithMessage("Please specify an email");
            RuleFor(createCustomerRequest => createCustomerRequest.Email).MaximumLength(100).WithMessage("Email must not exceed 200 characters");
            RuleFor(createCustomerRequest => createCustomerRequest.Email).EmailAddress().WithMessage("Must be a valid email");

        }
    }

}
