using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class PhotoView : MonoBehaviour
{
	[SerializeField] int SortingOrder;
	[SerializeField] Texture2D Photo;

	public void SetTexture(Texture2D texture2D)
	{
		MeshRenderer mesh = this.GetComponent<MeshRenderer>();
		Material material = new Material(mesh.sharedMaterial);
		material.SetTexture("Base Map", texture2D);
		mesh.material = material;
		mesh.sortingOrder = SortingOrder;
	}

	private void OnValidate()
	{
		SetTexture(Photo);
	}
}
