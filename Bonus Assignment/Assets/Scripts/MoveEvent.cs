using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEvent : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.StartListening("EnemyMove", EnemyMoveFunction);

    }
    void OnDisable()
    {
        EventManager.StopListening("EnemyMove", EnemyMoveFunction);
    }


    void EnemyMoveFunction()
    {

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), 8 * Time.deltaTime);
        Debug.Log("Enemy Move Function is called");

    }
}
