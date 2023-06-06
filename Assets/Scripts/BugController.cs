using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    public List<GameObject> BugsList;

    private float respawnCount = 0;

    public void Update()
    {
        foreach (GameObject BugGO in BugsList)
        {
            if (BugGO.activeSelf == false)
            {
                if(respawnCount>5)
                {
                    BugGO.SetActive(true);
                    respawnCount = 0;
                }
                respawnCount+= Time.deltaTime;

            }
        }
    }

}
