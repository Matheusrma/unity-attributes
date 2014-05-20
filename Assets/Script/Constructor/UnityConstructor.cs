using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public delegate void DConstruct(UnityEngine.Object obj); 

public static class UnityConstructor {

	private static Injector m_injector = new Injector();

	public static T Construct<T>(T prefab, params object[] args) where T:UnityEngine.Object{
		return Construct<T>(prefab, Vector3.zero, Quaternion.identity, args);
	}

	public static T Construct<T>(T prefab, Vector3 position, Quaternion rotation, params object[] constructorArgs) where T:UnityEngine.Object{

		T instantiatedObject = (T)GameObject.Instantiate(prefab, position, rotation);

		m_injector.SetContructorValues (instantiatedObject, constructorArgs);
		m_injector.InjectFields (instantiatedObject);

		return instantiatedObject;
	}
}
