using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ProjectRecord
{
	public string Name;   
	public E_Type Type;
	public List<string> People;
	public List<E_StuffType> Stuff;
}

public enum E_Type { Porting, FullCycle, Studio , CoDevelopment}
public enum E_StuffType { Unity, Backend }