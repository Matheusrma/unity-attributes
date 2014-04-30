using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class UnityConstructorParameterAtribute : Attribute{
	public UnityConstructorParameterAtribute(){

	}
}