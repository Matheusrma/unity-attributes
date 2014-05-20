using UnityEngine;
using System.Collections.Generic;

public interface IGameObjectBuilder
{
	T Build<T>(params object[] constructorArgs) where T:Component;

	IGameObjectBuilder FromResources(string resourcePath);
	IGameObjectBuilder ThisObject (Object original);

	IGameObjectBuilder At(Vector3 position);
	IGameObjectBuilder WithRotation(Quaternion rotation);
	IGameObjectBuilder ParentTo(Transform parent, bool resetScale);

	IGameObjectBuilder WithName(string name);
}

public class GameObjectBuilder : IGameObjectBuilder
{
	string m_resourcePath = "";
	
	Transform m_parent = null;
	bool m_resetScale = false;
	
	string m_name = "";

	Vector3 m_position = Vector3.zero;
	Quaternion m_rotation = Quaternion.identity;

	Object m_original = null;

	static GameObjectBuilder m_instance;

	public static IGameObjectBuilder Instance{
		get{
			if (m_instance == null)
				m_instance = new GameObjectBuilder();

			return m_instance;
		}
	}

	GameObjectBuilder(){}
	
	public T Build<T>(params object[] constructorArgs) where T:Component
	{
		Object toInstantiate = DefineOriginal();
		
		T newGo = (T)GameObject.Instantiate(toInstantiate, m_position, m_rotation);
		
		SetParent(newGo);
		SetName(newGo);

		var injector = new Injector();

		injector.InjectFields(newGo);
		injector.SetContructorValues(newGo, constructorArgs);

		return newGo;
	}

	public IGameObjectBuilder At(Vector3 position){
		m_position = position;
		return this;
	}

	public IGameObjectBuilder WithRotation(Quaternion rotation){
		m_rotation = rotation;
		return this;
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
	
	Object DefineOriginal()
	{
		if (m_original != null) return m_original;
		
		if (!m_resourcePath.Equals("")){
			return Resources.Load(m_resourcePath);
		}
		
		return new GameObject();
	}
	
	void SetParent (Component newGo)
	{
		if (m_parent != null) {
			newGo.transform.parent = m_parent;
			if (m_resetScale) {
				newGo.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}
	
	void SetName (Component newGo)
	{
		if (!m_name.Equals ("")) {
			newGo.name = m_name;
		}
	}
}
