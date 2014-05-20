Unity3D C# atributes to help Unity developers write code better and faster

List of Attributes:

UnityConstructorParameter: Sets a field to be on of contructor parameters of the type
UnityGameObjectInjection: Uses GameObject.Find() to inject an GameObject into the field
UnityComponentInjection: Uses Component.GetComponent<T>() to inject a Component into the field

For the injection to work you have to use one of the two building mechanisms or implement one of your own.

GameObjectBuilder: Uses the Builder Designer Pattern to simplify some of the instatiations
UnityContructor: Mimics the GameObject.instantiate call from Unity3D API



