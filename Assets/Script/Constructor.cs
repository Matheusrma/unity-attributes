using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public delegate void DConstruct(UnityEngine.Object obj); 

public class Constructor {

	public static T Construct<T>(T prefab, DConstruct constructor) where T:UnityEngine.Object{
		return Construct<T>(prefab, Vector3.zero, Quaternion.identity, constructor);
	}

	public static T Construct<T>(T prefab, Vector3 position, Quaternion rotation, DConstruct constructor) where T:UnityEngine.Object{
		
		T instantiatedObject = (T)GameObject.Instantiate(prefab, position, rotation);
		constructor(instantiatedObject);
		
		return instantiatedObject;
	}

	public static T Construct<T>(T prefab, params object[] args) where T:UnityEngine.Object{
		return Construct<T>(prefab, Vector3.zero, Quaternion.identity, args);
	}

	public static T Construct<T>(T prefab, Vector3 position, Quaternion rotation, params object[] args) where T:UnityEngine.Object{
		
		T instantiatedObject = (T)GameObject.Instantiate(prefab, position, rotation);
		
		Type objectType = instantiatedObject.GetType();
		var constructorPropertyList = new List<PropertyInfo>();
		
		objectType.GetProperties().ToList().ForEach((property) => {
			
			var att = (UnityConstructorParameterAtribute[]) property.GetCustomAttributes(typeof(UnityConstructorParameterAtribute), false);
			
			if (att.Length > 0){
				constructorPropertyList.Add(property);
			}
		});
		
		constructorPropertyList.Sort((x,y) =>{
			var xAtt = (UnityConstructorParameterAtribute[]) x.GetCustomAttributes(typeof(UnityConstructorParameterAtribute), false);
			var yAtt = (UnityConstructorParameterAtribute[]) y.GetCustomAttributes(typeof(UnityConstructorParameterAtribute), false);
			
			return xAtt[0].Position.CompareTo(yAtt[0].Position);
		});
		
		for (int i = 0; i < constructorPropertyList.Count; ++i){
			constructorPropertyList[i].SetValue(instantiatedObject, args[i], null);
		}
		
		return instantiatedObject;
	}
}
