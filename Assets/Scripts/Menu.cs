using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Main Scene", LoadSceneMode.Single);
        Debug.Log("loading Game");
    }
    public void loadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}
