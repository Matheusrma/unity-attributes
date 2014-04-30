using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public delegate void DConstruct(UnityEngine.Object obj); 

public static class UnityConstructor {

	public static T Construct<T>(T prefab, params object[] args) where T:UnityEngine.Object{
		return Construct<T>(prefab, Vector3.zero, Quaternion.identity, args);
	}

	public static T Construct<T>(T prefab, Vector3 position, Quaternion rotation, params object[] args) where T:UnityEngine.Object{
		
		T instantiatedObject = (T)GameObject.Instantiate(prefab, position, rotation);
		
		Type objectType = instantiatedObject.GetType();
		var constructorPropertyList = new List<PropertyInfo>();
		
		objectType.GetProperties().ToList().ForEach((property) => {
			var att = (UnityConstructorParameterAttribute[]) property.GetCustomAttributes(typeof(UnityConstructorParameterAttribute), false);
			
			if (att.Length > 0){
				constructorPropertyList.Add(property);
			}
		});

		constructorPropertyList.Sort((x,y) =>{
			var xAtt = (UnityConstructorParameterAttribute[]) x.GetCustomAttributes(typeof(UnityConstructorParameterAttribute), false);
			var yAtt = (UnityConstructorParameterAttribute[]) y.GetCustomAttributes(typeof(UnityConstructorParameterAttribute), false);
			
			return xAtt[0].Position.CompareTo(yAtt[0].Position);
		});
		
		for (int i = 0; i < constructorPropertyList.Count; ++i){
			constructorPropertyList[i].SetValue(instantiatedObject, args[i], null);
		}

		InjectFields (instantiatedObject, objectType);

		return instantiatedObject;
	}


	static void InjectFields (object instantiatedObject, Type objectType){
		objectType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList ().ForEach (field =>  {
			var att = (UnityInjectionAttribute[]) field.GetCustomAttributes(typeof(UnityInjectionAttribute), false);

			if (att.Length > 0) {
				UnityEngine.Object toInject = att[0].InjectionPolicy.GetToBeInjectedObject((MonoBehaviour)instantiatedObject);
				field.SetValue (instantiatedObject, toInject);
			}
		});
	}
}
