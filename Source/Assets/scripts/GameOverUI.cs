using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Return to Main UI");
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        Debug.Log("Reload");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
