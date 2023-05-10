using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PersonRecord 
{
	public string Name;
	public string Title;
	public string Project;

	public E_BodyColor Body;
	public E_HeadColor Head;
	public E_HeadMark Mark;
}

public enum E_BodyColor { Yellow, Orange, Puppur}
public enum E_HeadColor { Blue, Grey, Orange, Purpur, Pirat}
public enum E_HeadMark { None, Star, Sun }