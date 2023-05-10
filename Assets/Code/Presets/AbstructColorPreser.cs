using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstructColorPreser<T> : ScriptableObject where T: Enum
{
	[SerializeField] List<ColorPair> Colors = new List<ColorPair>();

	public Color ByType(T type) 
	{
		foreach (var item in Colors)
		{
			if (item.Key.Equals(type))
			{
				return item.Value;
			}
		}
		Debug.Log($"no color {type}");
		return Color.white;
	}

	[System.Serializable]
	public struct ColorPair
	{
		public T Key;
		public Color Value;
	}
}
