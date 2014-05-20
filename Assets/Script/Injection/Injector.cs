using UnityEngine;

using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class Injector {

	public Injector(){}

	public void SetContructorValues (object instantiatedObject, object[] constructorArgs) {
		var objectType = instantiatedObject.GetType();

		var constructorPropertyList = new List<PropertyInfo> ();
		
		objectType.GetProperties ().ToList ().ForEach (property =>  {
			var att = (UnityConstructorParameterAttribute[])property.GetCustomAttributes (typeof(UnityConstructorParameterAttribute), false);
			if (att.Length > 0) {
				constructorPropertyList.Add (property);
			}
		});
		
		constructorPropertyList.Sort ((x, y) =>  {
			var xAtt = (UnityConstructorParameterAttribute[])x.GetCustomAttributes (typeof(UnityConstructorParameterAttribute), false);
			var yAtt = (UnityConstructorParameterAttribute[])y.GetCustomAttributes (typeof(UnityConstructorParameterAttribute), false);
			return xAtt [0].Position.CompareTo (yAtt [0].Position);
		});
		for (int i = 0; i < constructorPropertyList.Count; ++i) {
			constructorPropertyList [i].SetValue (instantiatedObject, constructorArgs [i], null);
		}
	}
	
	public void InjectFields (object instantiatedObject){
		var objectType = instantiatedObject.GetType();

		objectType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).ToList ().ForEach (field =>  {
			var att = (UnityInjectionAttribute[]) field.GetCustomAttributes(typeof(UnityInjectionAttribute), false);
			
			if (att.Length > 0) {
				UnityEngine.Object toInject = att[0].InjectionPolicy.GetToBeInjectedObject((MonoBehaviour)instantiatedObject);
				field.SetValue (instantiatedObject, toInject);
			}
		});
	}
}
