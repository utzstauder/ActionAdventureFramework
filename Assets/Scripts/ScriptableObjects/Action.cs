﻿using UnityEngine;
using System.Collections;

public abstract class Action : ScriptableObject
{
    public abstract void DoAction(StateController controller);
}
