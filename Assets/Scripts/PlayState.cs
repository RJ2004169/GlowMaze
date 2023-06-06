using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : States
{
    public override IEnumerator Start()
    {
        cameraPosition = new Vector3(19.89f,10.5f,13.87f);
        cameraRotation = new Vector3(60, 0, 0);
        stateIndex = 1;
        uiEnabled = false;
        playerHealth = 100;
        spotLightEnabled = true;
        toggleAudio = true;
        return base.Start();
    }

}
