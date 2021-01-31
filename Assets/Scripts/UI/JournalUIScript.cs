using UnityEngine;

public class JournalUIScript : MonoBehaviour
{
    public static bool JournalShowing = false;
    public GameObject JournalUI;

    public PauseMenuScript PauseScript;

    void Start()
    {
        PauseScript = gameObject.GetComponent<PauseMenuScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !PauseMenuScript.GamePaused && !GameOverScript.GameOver)
        {
            if (JournalShowing)
                HideJournal();
            else
                ShowJournal();
        }
    }

    public void ShowJournal()
    {
        JournalUI.gameObject.SetActive(true);
        JournalShowing = true;

        var player = GameObject.FindWithTag("Player").GetComponent<FirstPersonAIO>();
        player.ControllerPause();

        Time.timeScale = 0.0f;
    }

    public void HideJournal()
    {
        HideJournalUI();

        var player = GameObject.FindWithTag("Player").GetComponent<FirstPersonAIO>();
        player.ControllerPause();

        Time.timeScale = 1.0f;
    }

    public void HideJournalUI()
    {
        JournalUI.gameObject.SetActive(false);
        JournalShowing = false;
    }
}
