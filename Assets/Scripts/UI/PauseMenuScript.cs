using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseMenu;

    public JournalUIScript JournalScript;

    void Start()
    {
        JournalScript = gameObject.GetComponent<JournalUIScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverScript.GameOver)
        {
            if (GamePaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        PauseMenu.gameObject.SetActive(false);
        GamePaused = false;

        var player = GameObject.FindWithTag("Player").GetComponent<FirstPersonAIO>();
        player.ControllerPause();
        Time.timeScale = 1.0f;
    }

    public void PauseGame()
    {
        PauseMenu.gameObject.SetActive(true);
        GamePaused = true;
        if (JournalUIScript.JournalShowing)
        {
            JournalScript.HideJournal();
        }

        var player = GameObject.FindWithTag("Player").GetComponent<FirstPersonAIO>();
        player.ControllerPause();

        Time.timeScale = 0.0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);    
    }
}
