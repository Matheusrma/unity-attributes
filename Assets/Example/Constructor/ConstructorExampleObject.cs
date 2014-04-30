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

	public override string ToString ()
	{
		return string.Format ("[ConstructorExampleObject: Name={0}, Level={1}]", Name, Level);
	}
}
