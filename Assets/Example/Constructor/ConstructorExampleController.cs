using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstructorExampleController : MonoBehaviour {

	public ConstructorExampleObject myPrefab;

	void Start(){

		ConstructorExampleObject myObject = UnityConstructor.Construct<ConstructorExampleObject>(myPrefab,"First", 0);

		Debug.Log(myObject);

		myObject = UnityConstructor.Construct<ConstructorExampleObject>(myPrefab, Vector3.one, Quaternion.Euler(90,90,0),
		                                                           		"Second", 1);

		Debug.Log(myObject);

		myObject = GameObjectBuilder.Instance.ThisObject(myPrefab)
											 .At(Vector3.one)
											 .WithName("Third")
											 .Build<ConstructorExampleObject>("Third", 2);

		Debug.Log(myObject);
	}
}
