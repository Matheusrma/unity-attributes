using System;
using UnityEngine;

public interface IInjectionPolicy{
	UnityEngine.Object GetToBeInjectedObject(MonoBehaviour target);
}

public class GameObjectFindInjectionPolicy : IInjectionPolicy{

	public string Name{
		get; private set;
	}

	public GameObjectFindInjectionPolicy(string name){
		Name = name;
	}

	public UnityEngine.Object GetToBeInjectedObject(MonoBehaviour target){
		return GameObject.Find(Name);
	}
}

public class GetComponentInjectionPolicy : IInjectionPolicy{
	
	public Type ComponentType{
		get; private set;
	}
	
	public GetComponentInjectionPolicy(Type type){
		ComponentType = type;
	}
	
	public UnityEngine.Object GetToBeInjectedObject(MonoBehaviour target){
		return target.GetComponent(ComponentType.Name);
	}
}


