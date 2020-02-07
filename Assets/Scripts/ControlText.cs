using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour
{
    public GameObject Text_object = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text text = Text_object.GetComponent<Text>();
        if (this.transform.position.x == 716.8f)
        {
            text.text = "Cleared!!!";
        }
    }
}
