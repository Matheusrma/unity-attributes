using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructorExampleController : MonoBehaviour {

	public ConstructorExampleObject myPrefab;

	void Start(){
		var myObject = Constructor.Construct<ConstructorExampleObject>(myPrefab, (obj) => {
			((ConstructorExampleObject)obj).Name = "FirstType";
		});

		Debug.Log(myObject.Name);

		myObject = Constructor.Construct<ConstructorExampleObject>(myPrefab, "SecondType");

		Debug.Log(myObject.Name);
	}
}
