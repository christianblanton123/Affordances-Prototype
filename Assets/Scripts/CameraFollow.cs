using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject circle;
    public GameObject rectangle;
    SwapGameObject stateComponent;

    float x;
    float y;
    float z;
    [SerializeField] bool isCircle;
    private void Start()
    {
        stateComponent = player.GetComponent<SwapGameObject>();
        x = 0f;
        y = -0.25f;
        z = -1f;
    }
    void Update()
    {
        isCircle = stateComponent.mState == SwapGameObject.State.Circle ? true : false;
        x = isCircle ? circle.transform.position.x : rectangle.transform.position.x;
        setY(isCircle);
        gameObject.transform.position = new Vector3(x, y, z);
    }
    void setY(bool isCircle)
    {
        if (isCircle)
        {
            if (circle.transform.localPosition.y > 4.5 || circle.transform.localPosition.y < -10)
            {
                y = circle.transform.localPosition.y - 4.55f;
            }
            else
            {
                y = -0.25f;
            }
        } else
        {
            if (rectangle.transform.localPosition.y > 4.5 || rectangle.transform.localPosition.y < -10)
            {
                y = rectangle.transform.localPosition.y -4.55f;
            }
            else
            {
                y = -0.25f;
            }
        }
    }
}
