using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("Score: " + score);
    }
}
