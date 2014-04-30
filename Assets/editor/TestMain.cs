using UnityEditor;
using UnityEngine;

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

public class TestMain : EditorWindow {

	[MenuItem("TestMain/Open")]
	public static void ShowWindow(){
		TestMain window = (TestMain)EditorWindow.GetWindow (typeof (TestMain));
	}

	void OnProjectChange() {
	
		Assembly a = Assembly.LoadFile(Application.dataPath + "/../Library/ScriptAssemblies/Assembly-CSharp.dll");

		a.GetTypes().ToList().ForEach((type) =>{
			Debug.Log (type.Name);
		});
	}
}
