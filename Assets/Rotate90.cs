using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate90 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            transform.Rotate(new Vector3(0,0,1),90);
        }


    }
}
