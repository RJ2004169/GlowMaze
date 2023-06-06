using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartState : States
{
    
    
    public override IEnumerator Start()
    {
        
        uiEnabled = true;
        playerHealth = 100;
        timer = 0;
        cameraPosition = new Vector3(17.74f, 1, 18.36f);
        cameraRotation = new Vector3(0, 35, 0);
        stateIndex = 0;
        spotLightEnabled = false;
        toggleAudio = false;

        // Need to show Canvas and start Screen, Player and camera positions reset and then health also reset
        return base.Start();
    }

}
