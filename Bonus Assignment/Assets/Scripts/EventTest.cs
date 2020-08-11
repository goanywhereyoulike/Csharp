using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTest : MonoBehaviour
{ 
  




    void OnEnable()
    {
    
        EventManager.StartListening("EnemyMove", EnemyMoveFunction);

    }
    void OnDisable()
    {

        EventManager.StopListening("EnemyMove", EnemyMoveFunction);
    }

    void SomeFuncetion()
    {
        Debug.Log("Some function was called");

    }

    void EnemyMoveFunction()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), 8 * Time.deltaTime);
        Debug.Log("Enemy Move Function is called");

    }

}
