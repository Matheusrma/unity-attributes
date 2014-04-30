using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExampleController : MonoBehaviour {

	public ExampleObject myPrefab;

	void Start(){
		var myObject = Constructor.Construct<ExampleObject>(myPrefab, (obj) => {
			((ExampleObject)obj).Name = "FirstType";
		});

		Debug.Log(myObject.Name);

		myObject = Constructor.Construct<ExampleObject>(myPrefab, "SecondType");

		Debug.Log(myObject.Name);
	}
}
