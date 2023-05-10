using Assets.Code.Selector;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Person : MonoBehaviour, ISelectable
{

	[Header("View Reference")]
    [SerializeField] SpriteRenderer Figure;
	[SerializeField] SpriteRenderer Crown;
	[SerializeField] SpriteRenderer CrownFeature;
	[SerializeField] Image Photo;


	[Header("Config")]
	[SerializeField] BodyColorsPreset BodyColorsPreset;
	[SerializeField] HeadColorsPreset HeadColorsPreset;

	[SerializeField] GameObject outline;

    public event Action<ISelectable> MouseDown;
    public event Action<ISelectable> MouseUp;
    public event Action<ISelectable> MouseOver;
    public event Action<ISelectable> DoubleClick;
    public event Action<ISelectable> OnMouseRightClick;
    public event Action<ISelectable> OnDrag;

    public Transform Transform => transform;
	public bool IsSelected { get; protected set; }

	public void DrawPerson(PersonRecord record)
	{
		DrawFigure(record.Body);
		DrawCrown(record.Head);


		//Crown.sprite = data.Crown;
		//CrownFeature.sprite = data.CrownFeature;
		//Photo.sprite = data.Photo;
	}

	public void DrawFigure(E_BodyColor value)
	{
		Figure.color = BodyColorsPreset.ByType(value);
	}

	public void DrawCrown(E_HeadColor value)
	{
		//if(value = E_HeadColor.)
		Crown.color = HeadColorsPreset.ByType(value);
	}

    public void Select()
    {
		IsSelected = true;
		outline.SetActive(true);
	}

    public void Deselect()
    {
		IsSelected = false;
		outline.SetActive(false);
	}
}

[CreateAssetMenu(fileName = "BodyColorsPreset", menuName = "ScriptableObjects/Preset/Color/Body", order = 1000)]
public class BodyColorsPreset : AbstructColorPreser<E_BodyColor> { };

[CreateAssetMenu(fileName = "HeadColorsPreset", menuName = "ScriptableObjects/Preset/Color/Head", order = 1000)]
public class HeadColorsPreset : AbstructColorPreser<E_HeadColor> { };
