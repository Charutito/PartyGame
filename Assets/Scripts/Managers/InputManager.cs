﻿using System.Collections;
using GameUtils;
using UnityEngine;

namespace Managers
{
    public class InputManager : SingletonObject<InputManager>
    {
        #region Properties

        public bool AxisMoving { get { return (Mathf.Abs(AxisHorizontal) + Mathf.Abs(AxisVertical)) > 0; } }
        public float AxisHorizontal { get { return Input.GetAxisRaw("Horizontal"); } }
        public float AxisVertical { get { return Input.GetAxisRaw("Vertical"); } }
        public bool OpenConsole { get { return Input.GetKeyDown(KeyCode.BackQuote); } }
        #endregion
    }
}
