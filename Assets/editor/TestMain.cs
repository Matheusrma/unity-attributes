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

			type.GetMethods().ToList().ForEach((method) => {

				var testAtribute = (TestAtribute[])method.GetCustomAttributes(typeof(TestAtribute), false);

				if (testAtribute.Length > 0){
					Debug.Log(method.Name);
				}

			});
		});
	}
}
