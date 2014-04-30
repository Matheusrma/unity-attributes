using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class UnityConstructorParameterAttribute : Attribute{

	public int Position{
		get;
		private set;
	}

	public UnityConstructorParameterAttribute(int position){
		Position = position;
	}
}