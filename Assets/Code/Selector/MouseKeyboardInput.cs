using System;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Selector
{
    public class MouseKeyboardInput : InputController
    {        
        private MouseKeyboardInputSettings settings;

        public event Action MouseDown;
        public event Action MouseUp;
        public event Action DoubleClick;
        public event Action MouseRightDown;
        public event Action MouseRightUp;
        public event Action MultiselectButtonDown;
        public event Action MultiselectButtonUp;

        private float clicked = 0;
        private float clicktime = 0;

        public MouseKeyboardInput(MouseKeyboardInputSettings settings)
        {
            this.settings = settings;
        }
        public void Init()
        {
        }

        public void Update()
        {

            //if (CheckDoubleClick())
            //{
            //    MouseDown?.Invoke();
            //}
            //else
            //{
            //    DoubleClick?.Invoke();
            //}

            if (Input.GetMouseButtonDown(0))
            {
                MouseDown?.Invoke();
            }


            if (Input.GetMouseButtonUp(0))
            {
                MouseUp?.Invoke();
            }

            if (Input.GetMouseButtonDown(1))
            {
                MouseRightDown?.Invoke();
            }

            if (Input.GetMouseButtonUp(1))
            {
                MouseRightUp?.Invoke();
            }

            if (Input.GetKeyDown(settings.MultiselectButton))
            {
                MultiselectButtonDown?.Invoke();
            }

            if (Input.GetKeyUp(settings.MultiselectButton))
            {
                MultiselectButtonUp?.Invoke();
            }
        }


        private bool CheckDoubleClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                clicked++;
                if (clicked == 1) clicktime = Time.time;
            }

            if (clicked > 1 && Time.time - clicktime < settings.Clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                return true;
            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
            return false;
        }

        public Vector3 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    [System.Serializable]
    public class MouseKeyboardInputSettings
    {
        public KeyCode MultiselectButton = KeyCode.LeftControl;
        public float Clickdelay = 0.5f;
    }
}