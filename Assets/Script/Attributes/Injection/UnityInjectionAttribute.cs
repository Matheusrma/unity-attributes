using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnityInjectionAttribute : Attribute{
	
	public IInjectionPolicy InjectionPolicy{
		get;
		private set;
	}

	public UnityInjectionAttribute(IInjectionPolicy policy){
		InjectionPolicy = policy;
	}
}