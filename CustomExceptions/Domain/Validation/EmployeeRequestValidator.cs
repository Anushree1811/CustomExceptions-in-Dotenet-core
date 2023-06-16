using CustomExceptions.Domain.Exceptions;
using CustomExceptions.Entities;
using System.Text.RegularExpressions;

namespace CustomExceptions.Domain.Validation
{
    public static class EmployeeRequestValidator
    {
        
        public static void Validate(EmployeeRequest employeeRequest) {

            if (employeeRequest == null)
            {

                throw new EmployeeArgumentExceptions($"{nameof(EmployeeRequest)} is null");

            }
            else if (string.IsNullOrWhiteSpace(employeeRequest.Name))
            {

                // throw new EmployeeArgumentExceptions($"{nameof(EmployeeRequest.Name)} is null/empty/Whitespace") 
                throw new IndexOutOfRangeException();

            }
            else if (string.IsNullOrWhiteSpace(employeeRequest.Mobile))
            {

                throw new EmployeeArgumentExceptions($"{nameof(EmployeeRequest.Mobile)} is null/empty/Whitespace");

            }
            else if (employeeRequest.Mobile.Length != 10)
            {

                throw new EmployeeArgumentExceptions($"{nameof(employeeRequest.Mobile)} is invalid length");

            }
            else if (string.IsNullOrWhiteSpace(employeeRequest.Email))
            {

                throw new EmployeeArgumentExceptions($"{nameof(EmployeeRequest.Email)} is null/empty/Whitespace");

            }
            else if (employeeRequest.Email.Length > 0) {

                Regex emailRegex = new Regex(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$");

                if (!emailRegex.IsMatch(employeeRequest.Email)) {

                    throw new EmployeeArgumentExceptions($"{nameof(employeeRequest.Email)} is in invalid format.");
                }

            }
            else if (string.IsNullOrWhiteSpace(employeeRequest.Role))
            {

                throw new EmployeeArgumentExceptions($"{nameof(EmployeeRequest.Role)} is null/empty/Whitespace");

            }
        }
    }
}
