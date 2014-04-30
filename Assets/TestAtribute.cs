using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class TestAtribute : Attribute
{
	public TestAtribute(){

	}
}