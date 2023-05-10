using System;
using UnityEngine;

namespace Assets.Code.Selector
{
    public interface ISelectable
    {
        bool IsSelected { get; }
        Transform Transform { get; }

        event Action<ISelectable> MouseDown;
        event Action<ISelectable> MouseUp;
        event Action<ISelectable> MouseOver;
        event Action<ISelectable> DoubleClick;
        event Action<ISelectable> OnMouseRightClick;
        event Action<ISelectable> OnDrag;

        void Select();
        void Deselect();
    }
}