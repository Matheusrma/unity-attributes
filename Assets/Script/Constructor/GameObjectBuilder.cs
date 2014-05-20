using UnityEngine;
using System.Collections.Generic;

public interface IGameObjectBuilder
{
	GameObject Construct();
	
	IGameObjectBuilder FromResources(string resourcePath);
	IGameObjectBuilder ParentTo(Transform parent, bool resetScale);
	IGameObjectBuilder ThisObject (Object original);
	IGameObjectBuilder WithName(string name);
}

public class GameObjectBuilder : IGameObjectBuilder
{
	string m_resourcePath = "";
	
	Transform m_parent = null;
	bool m_resetScale = false;
	
	string m_name = "";
	
	Object m_original = null;
	
	public GameObjectBuilder(){}
	
	public GameObject Construct ()
	{
		Object toInstantiate = DefineOriginal();
		
		var newGo = (GameObject)GameObject.Instantiate(toInstantiate);
		
		SetParent(newGo);
		SetName(newGo);
		
		return newGo;
	}
	
	public IGameObjectBuilder FromResources (string resourcePath)
	{
		m_resourcePath = resourcePath;
		return this;
	}
	
	public IGameObjectBuilder ThisObject (Object original)
	{
		m_original = original;
		return this;
	}
	
	public IGameObjectBuilder ParentTo (Transform parent, bool resetScale)
	{
		m_parent = parent;
		m_resetScale = resetScale;
		return this;
	}
	
	public IGameObjectBuilder WithName (string name)
	{
		m_name = name;
		return this;
	}
	
	private Object DefineOriginal()
	{
		if (m_original != null) return m_original;
		
		if (!m_resourcePath.Equals("")){
			return Resources.Load(m_resourcePath);
		}
		
		return new GameObject();
	}
	
	void SetParent (GameObject newGo)
	{
		if (m_parent != null) {
			newGo.transform.parent = m_parent;
			if (m_resetScale) {
				newGo.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}
	
	void SetName (GameObject newGo)
	{
		if (!m_name.Equals ("")) {
			newGo.name = m_name;
		}
	}
}
