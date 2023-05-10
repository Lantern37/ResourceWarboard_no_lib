using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Code.Selector
{
    public interface ISelector
    {
        public void Init(SelectorController controller);
        public void Update();

        public void DeInit();

        public void MouseDown(ISelectable selectable);
        public void MouseUp();
        public void MouseOver(ISelectable selectable);
        public void DoubleClick(ISelectable selectable);
        public void OnMouseRightClick(ISelectable selectable);
        public void OnDrag(ISelectable selectable);
        public void EmptyClick();
    }
}