using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class SingleSelector : ISelector
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

            if (controller.Selectables.Contains(selectable))
            {
                return;
            }

            controller.DeselectAll();
            

            controller.AddSelectable(selectable);

            //foreach (var item in controller.Selectables)
            //{
            //    offset.Add((Vector2)item.Transform.position - controller.GetMousePosition());
            //}
        }

        public void OnDrag(ISelectable selectable)
        {
            //for (int i = 0; i < controller.Selectables.Count; i++)
            //{
            //    controller.Selectables[i].Transform.position = controller.GetMousePosition() + offset[i];
            //}
        }

        public void MouseOver(ISelectable selectable)
        {
            //add some func
        }

        public void MouseUp()
        {
            isStartDragging = false;
        }

        public void DoubleClick(ISelectable selectable)
        {
            //add some func
        }

        public void OnMouseRightClick(ISelectable selectable)
        {
            //add some func
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