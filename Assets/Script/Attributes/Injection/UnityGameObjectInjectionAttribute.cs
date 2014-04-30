using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnityGameObjectInjectionAttribute : UnityInjectionAttribute{

	public UnityGameObjectInjectionAttribute(string name) : 
		base(new GameObjectFindInjectionPolicy(name)){}

}