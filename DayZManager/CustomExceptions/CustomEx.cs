using System;
namespace CustomExceptions;

public class CustomEx : Exception
{
	public CustomEx(string message) : base(message)
	{
	}
}

