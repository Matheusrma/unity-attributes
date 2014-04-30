using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnityComponentInjectionAttribute : UnityInjectionAttribute{

	public UnityComponentInjectionAttribute(Type type) : 
		base(new GetComponentInjectionPolicy(type)){}

}