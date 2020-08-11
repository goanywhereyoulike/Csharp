using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObjectManager datamanager;
    // Start is called before the first frame update
    void Start()
    {
        if (datamanager == null)
        {
            datamanager.GetComponent<GameObjectManager>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
