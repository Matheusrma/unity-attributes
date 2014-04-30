using UnityEngine;
using System.Collections;

public class TestObject : MonoBehaviour {

	[UnityConstructorParameterAtribute(0)]
	public string Name{
		get;
		set;
	}
}
