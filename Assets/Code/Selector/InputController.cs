using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputController
{
    event Action MouseDown;
    event Action MouseUp;
    event Action DoubleClick;
    event Action MouseRightDown;
    event Action MouseRightUp;
    event Action MultiselectButtonDown;
    event Action MultiselectButtonUp;

    void Init();
    void Update();
}
