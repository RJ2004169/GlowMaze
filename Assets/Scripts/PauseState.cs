using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : States
{
    public override IEnumerator Start()
    {
        stateIndex = 2;
        uiEnabled = true;
        return base.Start();
    }
}
