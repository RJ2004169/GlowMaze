using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States
{
   
    public bool uiEnabled;
    public bool spotLightEnabled;
    public bool toggleAudio;
    public float playerHealth;
    public float timer;
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;
    public int stateIndex;
    public virtual IEnumerator Start()
    {
        yield break;
    }
    
}
