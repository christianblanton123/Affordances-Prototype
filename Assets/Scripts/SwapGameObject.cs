using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    public enum State { Circle, Rectangle };
    public State mState;
    public GameObject circle;
    public GameObject rectangle;
    void Start()
    {
        mState = State.Circle;

    }

    // Update is called once per frame
    void Update()
    {
        if (mState == State.Circle)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))//transition to rect
            {
                rectangle.GetComponent<Movement>().moveVelocity = circle.GetComponent<Movement>().moveVelocity;
                mState = State.Rectangle;
                rectangle.SetActive(true);
                circle.SetActive(false);
            }
            rectangle.transform.position = circle.transform.position;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))//transition to circle
            {
                circle.GetComponent<Movement>().moveVelocity = rectangle.GetComponent<Movement>().moveVelocity;
                mState = State.Circle;
                rectangle.SetActive(false);
                circle.SetActive(true);
            }
            circle.transform.position = rectangle.transform.position;
        }
        
    }
}
