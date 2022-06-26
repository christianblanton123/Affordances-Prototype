using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject circle;
    public GameObject rectangle;
    SwapGameObject stateComponent;
    private void Start()
    {
         stateComponent = player.GetComponent<SwapGameObject>();
    }
    void Update()
    {
        float x = 0f;
        float y = -0.25f;
        float z = -1f;
        x = stateComponent.mState == SwapGameObject.State.Circle ? circle.transform.position.x : rectangle.transform.position.x;
        //y = stateComponent.mState == SwapGameObject.State.Circle ? circle.transform.position.y : rectangle.transform.position.y;
        

        gameObject.transform.position = new Vector3(x, y, z);
    }
}
