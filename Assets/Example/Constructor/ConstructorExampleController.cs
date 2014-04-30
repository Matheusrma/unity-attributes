using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructorExampleController : MonoBehaviour {

	public ConstructorExampleObject myPrefab;

	void Start(){
		var myObject = Constructor.Construct<ConstructorExampleObject>(myPrefab, (obj) => {
			((ConstructorExampleObject)obj).Name = "FirstType";
			((ConstructorExampleObject)obj).Level = 0;
		});

		Debug.Log(myObject);

		myObject = Constructor.Construct<ConstructorExampleObject>(myPrefab, Vector3.one, Quaternion.Euler(90,90,0) , "SecondType", 1);

		Debug.Log(myObject);
	}
}
