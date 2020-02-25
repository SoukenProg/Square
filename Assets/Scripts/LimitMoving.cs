using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitMoving : MonoBehaviour
{
    GameObject obj;
    float mini, maxi;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(this.name == "Right")
        {
            MovePlayer.maxLimitx = obj.transform.position.x;
        }
        else
        {
            MovePlayer.minLimitx = obj.transform.position.x;
        }
    }
}
