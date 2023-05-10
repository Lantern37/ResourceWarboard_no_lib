using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class MultiSelector : ISelector
    {
        private SelectorController controller;
        private bool isStartDragging;
        private float dragDistanse = 0.3f;
        private Vector2 startDragingPoint;
        public void Init(SelectorController controller)
        {
            this.controller = controller;
        }
        public void EmptyClick()
        {
            controller.DeselectAll();
        }

        public void MouseDown(ISelectable selectable)
        {
            isStartDragging = true;
            startDragingPoint = controller.GetMousePosition();

            if (controller.Selectables.Contains(selectable))
            {
                //offset.Remove(selectable);
                //controller.DeleteSelectable(selectable);
            }
            else
            {
                controller.AddSelectable(selectable);
            }
        }
        public void OnDrag(ISelectable selectable)
        {

        }

        public void MouseOver(ISelectable selectable)
        {
        }

        public void MouseUp()
        {
            isStartDragging = false;
        }

        public void OnMouseRightClick(ISelectable selectable)
        {
        }

        public void DoubleClick(ISelectable selectable)
        {
        }

        public void Update()
        {
            if (isStartDragging && Vector2.Distance(startDragingPoint, controller.GetMousePosition()) > dragDistanse && controller.Selectables.Count > 0)
            {
                foreach (var item in controller.Selectables)
                {
                    item.Transform.position = controller.GetMousePosition() + controller.Offset[item];
                }
            }
        }

        public void DeInit()
        {
        }
    }
}