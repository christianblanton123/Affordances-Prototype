using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPoint : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer rend;
    bool touched;
    GameObject scoreObj;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        scoreObj = GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Circle")|| collision.gameObject.CompareTag("Rectangle"))
        {
            if (!touched)
            {
                rend.color = new Color(0.35f, 0.6f, 0.35f);
                transform.Rotate(0.0f, 0.0f, 90.0f);
                transform.localScale = new Vector3(0.5f,1,1);
                scoreObj.GetComponent<SetScore>().score++;
            }

            touched = true;
        }
    }
    
}
