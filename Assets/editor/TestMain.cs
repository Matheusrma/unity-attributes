using UnityEditor;
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class TestMain : Editor {

	static string ASSEMBLY_PATH = Application.dataPath + "/../Library/ScriptAssemblies/Assembly-CSharp.dll";

	[MenuItem("TestMain/Generate")]
	static void Generate() {
		Assembly a = Assembly.LoadFile(ASSEMBLY_PATH);

		a.GetTypes().ToList().ForEach((type) =>{

			var constructorPropertyList = new List<PropertyInfo>();

			type.GetProperties().ToList().ForEach((property) => {

				var att = (UnityConstructorParameterAtribute[]) property.GetCustomAttributes(typeof(UnityConstructorParameterAtribute), false);

				if (att.Length > 0){
					constructorPropertyList.Add(property);
				}
			});

		});
	}
}
