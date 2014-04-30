using System;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class UnityConstructorParameterAtribute : Attribute{

	public int Position{
		get;
		private set;
	}

	public UnityConstructorParameterAtribute(int position){
		Position = position;
	}
}