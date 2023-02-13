using Customer.Domain.DTOs;
using FluentValidation;

namespace Customer.API.Filters
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(updateCustomerRequest => updateCustomerRequest.ID).NotNull().WithMessage("Please specify an ID");
            RuleFor(updateCustomerRequest => updateCustomerRequest.ID).GreaterThan(0).WithMessage("ID must be greater than 0");

            RuleFor(updateCustomerRequest => updateCustomerRequest.FirstName).NotEmpty().NotNull().WithMessage("Please specify a first name");
            RuleFor(updateCustomerRequest => updateCustomerRequest.FirstName).MaximumLength(50).WithMessage("First Name must not exceed 50 characters");

            RuleFor(updateCustomerRequest => updateCustomerRequest.LastName).NotEmpty().NotNull().WithMessage("Please specify a last name");
            RuleFor(updateCustomerRequest => updateCustomerRequest.LastName).MaximumLength(50).WithMessage("Last Name must not exceed 50 characters");

            RuleFor(updateCustomerRequest => updateCustomerRequest.CustomerCode).NotEmpty().NotNull().WithMessage("Please specify a Customer Code");

            RuleFor(updateCustomerRequest => updateCustomerRequest.PhoneNo).NotEmpty().NotNull().WithMessage("Please specify a phone number");
            RuleFor(updateCustomerRequest => updateCustomerRequest.PhoneNo).MaximumLength(20).WithMessage("Phone number must not exceed 20 characters");

            RuleFor(updateCustomerRequest => updateCustomerRequest.HouseAddress).NotEmpty().NotNull().WithMessage("Please specify a house address");
            RuleFor(updateCustomerRequest => updateCustomerRequest.HouseAddress).MaximumLength(200).WithMessage("House Address must not exceed 200 characters");

            RuleFor(updateCustomerRequest => updateCustomerRequest.AccountNumber).NotEmpty().NotNull().WithMessage("Please specify an account number");
            RuleFor(updateCustomerRequest => updateCustomerRequest.AccountNumber).MaximumLength(10).WithMessage("AccountNumber must not exceed 10 characters");

            RuleFor(updateCustomerRequest => updateCustomerRequest.Email).NotEmpty().NotNull().WithMessage("Please specify an email");
            RuleFor(updateCustomerRequest => updateCustomerRequest.Email).MaximumLength(100).WithMessage("Email must not exceed 200 characters");
            RuleFor(createCustomerRequest => createCustomerRequest.Email).EmailAddress().WithMessage("Must be a valid email");


        }
    }
}
