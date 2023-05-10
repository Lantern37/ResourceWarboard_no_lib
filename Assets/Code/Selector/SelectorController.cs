using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class SelectorController
    {
        private SelectorFactory selectorFactory;
        private Dictionary<SelectorType, ISelector> activeSelectors;
        private InputController input;

        public List<ISelectable> Selectables { get; protected set; }

        public Dictionary<ISelectable, Vector2> Offset { get; protected set; }

        public SelectorController(SelectorFactory selectorFactory, InputController inputController)
        {
            this.input = inputController;
            this.selectorFactory = selectorFactory;
        }

        public void Init()
        {
            activeSelectors = new Dictionary<SelectorType, ISelector>();
            Selectables = new List<ISelectable>();
            Offset = new Dictionary<ISelectable, Vector2>();

            AddSelector(SelectorType.SingleSelector);
            AddSelector(SelectorType.StrokeSelector);

            ConnectInput();
        }
        public void Update()
        {
            if(activeSelectors != null && activeSelectors.Count > 0)
            {
                foreach (var sel in activeSelectors.Values)
                {
                    sel.Update();
                }
            }

            //onmouseOver
        }

        public void DeselectAll()
        {
            if (Selectables == null && Selectables.Count > 0)
                return;

            foreach (var item in Selectables)
            {
                item.Deselect();
            }

            ClearSelectables();
        }

        public void ClearSelectables()
        {
            Selectables.Clear();
        }

        public void DeleteSelectable(ISelectable selectable)
        {
            if (Selectables.Contains(selectable))
            {
                selectable.Deselect();
                Offset.Remove(selectable);
                Selectables.Remove(selectable);
            }
        }

        public void AddSelectable(ISelectable selectable)
        {
            if (!Selectables.Contains(selectable))
            {
                Selectables.Add(selectable);
                Offset.Add(selectable, selectable.Transform.position);
                selectable.Select();
            }
        }

        public Vector2 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        }

        public void ConnectInput()
        {
            input.MouseDown += MouseDown;
            input.MouseUp += MouseUp;
            input.DoubleClick += DoubleClick;
            input.MouseRightDown += MouseRightDown;
            input.MouseRightUp += MouseRightUp;
            input.MultiselectButtonDown += MultiselectButtonDown;
            input.MultiselectButtonUp += MultiselectButtonUp;
        }

        public void DisConnectInput()
        {
            input.MouseDown -= MouseDown;
            input.MouseUp -= MouseUp;
            input.DoubleClick -= DoubleClick;
            input.MouseRightDown -= MouseRightDown;
            input.MouseRightUp -= MouseRightUp;
            input.MultiselectButtonDown -= MultiselectButtonDown;
            input.MultiselectButtonUp -= MultiselectButtonUp;
        }

        private void AddSelector(SelectorType selectorType)
        {
            if (!activeSelectors.ContainsKey(selectorType))
            {
                var sel = selectorFactory.GetSelector(selectorType);
                activeSelectors.Add(selectorType, sel);
                sel.Init(this);
            }
        }
        private void RemoveSelector(SelectorType selectorType)
        {
            if (activeSelectors.ContainsKey(selectorType))
            {
                var sel = activeSelectors[selectorType];
                sel.DeInit();
                activeSelectors.Remove(selectorType);
            }
        }
        private void MouseDown()
        {
            //selector.MouseDown()
            var selectedObject = GetSelectableFromRay();
            
            if (selectedObject != null)
            {
                if (activeSelectors != null && activeSelectors.Count > 0)
                {
                    foreach (var sel in activeSelectors.Values)
                    {
                        sel.MouseDown(selectedObject);
                    }
                }
            }
            else
            {
                if (activeSelectors != null && activeSelectors.Count > 0)
                {
                    foreach (var sel in activeSelectors.Values)
                    {
                        sel.EmptyClick();
                    }
                }
            }
        }

        private void MouseUp()
        {
            if (activeSelectors != null && activeSelectors.Count > 0)
            {
                foreach (var sel in activeSelectors.Values)
                {
                    sel.MouseUp();
                }
            }
        }
        private void DoubleClick()
        {
            var selectedObject = GetSelectableFromRay();

            if (selectedObject != null)
            {
                if (activeSelectors != null && activeSelectors.Count > 0)
                {
                    foreach (var sel in activeSelectors.Values)
                    {
                        sel.DoubleClick(selectedObject);
                    }
                }
            }
        }
        private void MouseRightDown()
        {
            var selectedObject = GetSelectableFromRay();

            if (selectedObject != null)
            {
                if (activeSelectors != null && activeSelectors.Count > 0)
                {
                    foreach (var sel in activeSelectors.Values)
                    {
                        sel.OnMouseRightClick(selectedObject);
                    }
                }
            }
        }
        private void MouseRightUp()
        {

        }
        private void MultiselectButtonDown()
        {
            RemoveSelector(SelectorType.SingleSelector);
            AddSelector(SelectorType.Multiselector);
        }
        private void MultiselectButtonUp()
        {
            RemoveSelector(SelectorType.Multiselector);
            AddSelector(SelectorType.SingleSelector);
        }

        public ISelectable GetSelectableFromRay()
        {            
            RaycastHit2D hit = Physics2D.Raycast(GetMousePosition(), Vector2.zero);

            if (hit.collider != null && hit.collider.GetComponent<ISelectable>() != null)
            {
                return hit.collider.GetComponent<ISelectable>();
            }

            return null;
        }
    }
}