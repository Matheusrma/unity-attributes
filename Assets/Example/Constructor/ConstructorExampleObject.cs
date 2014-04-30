using UnityEngine;
using System.Collections;

public class ConstructorExampleObject : MonoBehaviour {

	[UnityConstructorParameter(0)]
	public string Name{
		get;
		set;
	}

	[UnityConstructorParameter(1)]
	public int Level{
		get;
		set;
	}

	[UnityInjection(GameObjectName = "InjectMe")]
	private GameObject m_injection;

//	[UnityInjection(Component = Rigidbody)
//	private Rigidbody m_injectedRigidbody;

	//Happens before the property setting
	//Don't use the ConstructorParameters Properties here
	void Awake(){

	}

	//Happens after the property setting. 
	//You should start using the ConstructorParameters Properties here
	void Start(){

		gameObject.name = Name;
		Debug.Log(m_injection.name);

	}

	public override string ToString (){
		return string.Format ("[ConstructorExampleObject: Name={0}, Level={1}]", Name, Level);
	}
}
