using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ArcanoMenorStateMachine
{
    public ArcanoMenorState _CurrentState;

    public void ChangeState (ArcanoMenorState newState)
    {
        _CurrentState = newState;
    }
}
