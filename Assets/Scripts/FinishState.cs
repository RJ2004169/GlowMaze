using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishState : States
{
    public override IEnumerator Start()
    {
        stateIndex = 4;
        uiEnabled = true;
        return base.Start();
    }
}
