using UnityEngine;
using System.Collections;

public class ConstructorExampleObject : MonoBehaviour {

	[UnityConstructorParameterAtribute(0)]
	public string Name{
		get;
		set;
	}
}
