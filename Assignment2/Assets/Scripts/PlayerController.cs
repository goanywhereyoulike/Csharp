using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerObject myplayer;
    public bool isMoveable = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoveable==true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                myplayer.TakeHit(10);
                Debug.Log(myplayer.hp);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {

                    Debug.Log("Origin Position: " + myplayer.position);
                    myplayer.MoveTo(hit.point);
     
                    transform.position = Vector3.Lerp(transform.position, myplayer.position, 20 * Time.deltaTime);
                    //transform.Translate(hit.point,Space.World);
                    Debug.Log("New Position: " + myplayer.position);
                }

            }
        }
    }



}
