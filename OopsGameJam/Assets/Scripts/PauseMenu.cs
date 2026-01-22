using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;
    public GameObject controlsMenu;
    public static bool isControls = false;

    public AudioSource buttonPress;
    

    void Start()
    {
        isPaused = false;
        isControls = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true && isControls == false)
            {
                ResumeGame();
            }
            else if (isPaused == false && isControls == false)
            {
                PauseGame();
            }

            if (isPaused == true && isControls == true)
            {
                controlsMenu.SetActive(false);
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isControls = false;
    }

    public void Controls()
    {
        controlsMenu.SetActive(true);
        isControls = true;
    }
    
    public void ButtonNoise()
    {
        buttonPress.Play();
    }
}
