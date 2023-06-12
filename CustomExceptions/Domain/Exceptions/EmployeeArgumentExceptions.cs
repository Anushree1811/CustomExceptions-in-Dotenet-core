namespace CustomExceptions.Domain.Exceptions;

public class EmployeeArgumentExceptions : Exception
{
	//Default Constructor
	public EmployeeArgumentExceptions()
	{

	}

	public EmployeeArgumentExceptions(string message) : base(message) { 
	
	
	}


	//Constructor with message and inner exception
	public EmployeeArgumentExceptions(string message, Exception inner) : base(message, inner) { 
	
	}


	
}
