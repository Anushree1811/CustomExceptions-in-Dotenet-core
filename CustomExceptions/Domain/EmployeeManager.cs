using CustomExceptions.Domain.Validation;
using CustomExceptions.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CustomExceptions.Domain;

public class EmployeeManager
{
    

    public void SaveEmployeeDetails(EmployeeRequest employeeRequest)
    {

        EmployeeRequestValidator.Validate(employeeRequest);
          
    }

    public EmployeeResponse GetEmployeeDetails(int id)
    {
        return new EmployeeResponse
        {
            Id =1,
            Name = "Raj",
            Salary = 10000,
            Manager = "Robert"
        };


    }
}
