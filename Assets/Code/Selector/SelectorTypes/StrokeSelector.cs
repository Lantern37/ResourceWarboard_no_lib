using UnityEngine;

namespace Assets.Code.Selector
{
    public class StrokeSelector : ISelector
    {
        private SelectorController controller;
        private StrokeSelectorSettings settings;
        private bool isSelectStarted;
        private Vector2 firstPoint;

        private StrokeSelectorRect currentShapeToDraw;
        private bool isDrawingShape;

        public StrokeSelector(StrokeSelectorSettings settings)
        {
            this.settings = settings;
        }

        public void Init(SelectorController controller)
        {
            this.controller = controller;
        }

        public void EmptyClick()
        {
            controller.DeselectAll();

            controller.DeselectAll();
            isSelectStarted = true;
            firstPoint = controller.GetMousePosition();

            AddShapeVertex(firstPoint);
        }

        public void MouseDown(ISelectable selectable)
        {
            //controller.DeselectAll();
            //isSelectStarted = true;
            //firstPoint = controller.GetMousePosition();

            //AddShapeVertex(firstPoint);
        }

        public void OnDrag(ISelectable selectable)
        {
        }

        public void MouseOver(ISelectable selectable)
        {
            //add some func
        }

        public void MouseUp()
        {
            isSelectStarted = false;
            DestroySelectorRect();
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
            var mousePos = controller.GetMousePosition();
            
            if (isSelectStarted && Vector3.Distance(firstPoint, mousePos) >= settings.MinDistance)
            {

                var canUpdateShape = currentShapeToDraw != null && isDrawingShape;

                if (canUpdateShape)
                {
                    UpdateShapeVertex(mousePos);
                }
            }
        }

        public void DeInit()
        {
            DestroySelectorRect();
        }

        public void EnterSelectable(ISelectable selectable)
        {
            controller.AddSelectable(selectable);
        }

        public void ExitSelectable(ISelectable selectable)
        {
            controller.DeleteSelectable(selectable);
        }

        private void AddShapeVertex(Vector2 position)
        {
            if (currentShapeToDraw == null)
            {
                currentShapeToDraw = CreateSelectorRect();
                currentShapeToDraw.name = "Rect";

                currentShapeToDraw.AddVertex(firstPoint);
                currentShapeToDraw.AddVertex(position);

                isDrawingShape = true;
            }
            else
            {
                isDrawingShape = !currentShapeToDraw.ShapeFinished;

                if (isDrawingShape)
                {
                    currentShapeToDraw.AddVertex(position);
                }
            }
        }

        private StrokeSelectorRect CreateSelectorRect()
        {
            var rect = Object.Instantiate(settings.StrokeSelectorRect);
            rect.EnterTriggerSelectable += EnterSelectable;
            rect.ExitTriggerSelectable += ExitSelectable;
            return rect;
        }

        private void DestroySelectorRect()
        {
            if (currentShapeToDraw == null)
                return;

            currentShapeToDraw.EnterTriggerSelectable -= EnterSelectable;
            currentShapeToDraw.ExitTriggerSelectable -= ExitSelectable;
            Object.Destroy(currentShapeToDraw.gameObject);
            currentShapeToDraw = null;
        }

        private void UpdateShapeVertex(Vector2 position)
        {
            if (currentShapeToDraw == null)
            {
                return;
            }

            currentShapeToDraw.UpdateShape(position);
        }
    }

    [System.Serializable]
    public class StrokeSelectorSettings
    {
        public StrokeSelectorRect StrokeSelectorRect;
        public float MinDistance;
    }
}