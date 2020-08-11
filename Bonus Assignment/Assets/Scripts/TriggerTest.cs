using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            EventManager.TriggerEvent("EventTest");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
           
            EventManager.TriggerEvent("EnemyMove");

        }
    }
}
