﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Transition
{
    public Condition condition;
    public State trueState;
    public State falseState;
}
