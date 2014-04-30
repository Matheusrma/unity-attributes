using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnityInjectionAttribute : Attribute{

	public string GameObjectName{
		get;
		set;
	}

	public UnityInjectionAttribute(){

	}

	public bool ShouldFindGameObjectByName(){
		return GameObjectName != "";
	}
}