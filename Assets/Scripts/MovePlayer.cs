using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    bool istouched;
    Rigidbody2D rb;
    public  static float minLimitx, maxLimitx;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;//回転を固定
        minLimitx = -716.8f;
        maxLimitx = 716.8f;
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
                    Debug.Log("Touched");
                    break;

                case TouchPhase.Moved:
                    Debug.Log("Moving");
                    Vector3 touchPoint_screen = new Vector3(touch.position.x, touch.position.y, 0);
                    Vector3 screenPos = Camera.main.ScreenToWorldPoint(touchPoint_screen);
                    this.transform.position = screenPos;
                    break;

                case TouchPhase.Ended:
                    istouched = false;
                    Debug.Log("Released");
                    break;
            }
        }
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, minLimitx, maxLimitx),
            Mathf.Clamp(this.transform.position.y,-89.6f, -89.6f),
           Mathf.Clamp(this.transform.position.y, -1.0f, -1.0f));
    }

    void OnCollisionEnter(Collision other)
    {
        Vector3 Pos;
        foreach (ContactPoint point in other.contacts)
        {
            Pos = point.point;
            Debug.Log(Pos);
        }
    }

}
