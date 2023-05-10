using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class AbstructSpritePreser<T> : ScriptableObject where T: Enum
{
	[SerializeField] List<SpritePair> Colors = new List<SpritePair>();
	[SerializeField] Sprite Default;

	public Sprite ByType(T type) 
	{
		foreach (var item in Colors)
		{
			if (item.Key.Equals(type))
			{
				return item.Value;
			}
		}
		Debug.Log($"no Sprite {type}");
		return Default;
	}

	[System.Serializable]
	public struct SpritePair
	{
		public T Key;
		public Sprite Value;
	}
}
