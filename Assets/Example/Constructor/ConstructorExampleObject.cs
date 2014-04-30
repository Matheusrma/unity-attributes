using UnityEngine;
using System.Collections;

public class ConstructorExampleObject : MonoBehaviour {

	[UnityConstructorParameterAtribute(0)]
	public string Name{
		get;
		set;
	}

	[UnityConstructorParameterAtribute(1)]
	public int Level{
		get;
		set;
	}

	//Happens before the property setting
	//Don't use the ConstructorParameters Properties here
	void Awake(){

	}

	//Happens after the property setting. 
	//You should start using the ConstructorParameters Properties here
	void Start(){
		gameObject.name = Name;
	}

	public override string ToString (){
		return string.Format ("[ConstructorExampleObject: Name={0}, Level={1}]", Name, Level);
	}
}
