using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : States
{
    public override IEnumerator Start()
    {
        uiEnabled = true;
        stateIndex = 3;
        return base.Start();
    }
}
