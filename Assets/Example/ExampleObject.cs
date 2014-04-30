using UnityEngine;
using System.Collections;

public class ExampleObject : MonoBehaviour {

	[UnityConstructorParameterAtribute(0)]
	public string Name{
		get;
		set;
	}
}
