using System;
 
using UnityEngine;
 
[Serializable]
public class StringIntDictionary : SerializableDictionary<string, int> {}
 
[Serializable]
public class GameObjectFloatDictionary : SerializableDictionary<GameObject, float> {}

[Serializable]
public class StringGameObjectDictionary : SerializableDictionary<string, GameObject> {}

