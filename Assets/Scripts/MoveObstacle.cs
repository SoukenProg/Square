using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    Vector3 Scale,Size;
    Transform tr;
    Rigidbody2D rb;
    static float minLimitx, maxLimitx, minLimity, maxLimity;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        Scale = tr.position;
        Size = GetComponent<Transform>().lossyScale;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//回転を固定

        if(Size.y == 179.2f)
        {
            minLimitx = Scale.x;
            maxLimitx = Scale.x;
            minLimity = -716.8f;
            maxLimity = 716.8f;
        }else if(Size.x == 179.2f)
        {
            minLimitx = -716.8f;
            maxLimitx = 716.8f;
            minLimity = Scale.y;
            maxLimity = Scale.y;

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("Touched");
                    break;

                case TouchPhase.Moved:
                    Debug.Log("Moving");
                    Vector3 touchPoint_screen = new Vector3(touch.position.x, touch.position.y, 0);
                    Vector3 screenPos = Camera.main.ScreenToWorldPoint(touchPoint_screen);
                    this.transform.position = screenPos;
                    break;

                case TouchPhase.Ended:
                    Debug.Log("Released");
                    break;
            }
        }
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minLimitx, maxLimitx),
        Mathf.Clamp(this.transform.position.y, minLimity, maxLimity),
       Mathf.Clamp(this.transform.position.y, -1.0f, -1.0f));
    }


    private void OnCollisionStay(Collision collision)
    {
        rb.velocity = Vector3.zero;
    }
}
