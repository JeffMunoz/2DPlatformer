// Author: Jeffry Munoz

using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuScreen;
    public static bool isPaused = false;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
            
        }    
    }

    public void resume()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pause()
    {
        pauseMenuScreen.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void loadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        print("Quit Pressed");
        Application.Quit();
    }
}
