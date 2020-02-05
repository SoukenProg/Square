using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    bool istouched;
    // Start is called before the first frame update
    void Start()
    {
        istouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    istouched = true;
                    break;

                case TouchPhase.Moved:
                    Vector3 touchPoint_screen = new Vector3(touch.position.x, touch.position.y, 0);
                    this.transform.position = touchPoint_screen;
                    break;

                case TouchPhase.Ended:
                    istouched = false;
                    break;
            }
        }
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -716.8f, 716.8f),
            Mathf.Clamp(this.transform.position.y,-89.6f, -89.6f),
           Mathf.Clamp(this.transform.position.y, -1.0f, -1.0f));
    }
    void FixedUpdate()
    {

    }
}
