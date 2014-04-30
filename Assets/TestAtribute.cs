using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class TestAtribute : Attribute
{
	public TestAtribute(){

	}
}