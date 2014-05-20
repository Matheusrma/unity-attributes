using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructorExampleController : MonoBehaviour {

	public ConstructorExampleObject myPrefab;

	void Start(){

		var myObject = UnityConstructor.Construct<ConstructorExampleObject>(myPrefab,"First", 0);

		Debug.Log(myObject);

		myObject = UnityConstructor.Construct<ConstructorExampleObject>(myPrefab, Vector3.one, Quaternion.Euler(90,90,0),
		                                                           		"Second", 1);

		Debug.Log(myObject);
	}
}
