using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainController : MonoBehaviour {

	public TestObject myPrefab;

	void Start(){
		var myObject = Constructor.Construct<TestObject>(myPrefab, (obj) => {
			((TestObject)obj).Name = "FirstType";
		});

		Debug.Log(myObject.Name);

		myObject = Constructor.Construct<TestObject>(myPrefab, "SecondType");

		Debug.Log(myObject.Name);
	}
}
