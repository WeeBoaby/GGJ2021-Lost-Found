using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private JournalUIScript JournalScript;

    public GameObject GameOverUI;

    public static bool GameOver = false;

    public List<GameObject> WonUI;
    public List<GameObject> LostUI;
    public List<GameObject> BothUI;

    public GameObject ScoreValue;
    public GameObject TimeValue;

    // Start is called before the first frame update
    void Start()
    {
        JournalScript = gameObject.GetComponent<JournalUIScript>();

        GameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameOver && (!MainPlayerScript.PlayerAlive || MainPlayerScript.PlayerWon))
        {
            Debug.Log("Game is over");
            GameOver = true;
            JournalScript.HideJournalUI();
            Time.timeScale = 0.0f;

            var player = GameObject.FindWithTag("Player").GetComponent<FirstPersonAIO>();
            player.ControllerPause();

            GameOverUI.SetActive(GameOver);

            ScoreValue.GetComponent<Text>().text = MainPlayerScript.PlayerScore.ToString() + " Points";
            TimeValue.GetComponent<Text>().text = System.Math.Round(MainPlayerScript.gameTime, 2).ToString() + " Seconds";

            if (!MainPlayerScript.PlayerAlive)
            {
                WonUI.ForEach(o => o.SetActive(false));
                BothUI.ForEach(o => o.SetActive(true));
                LostUI.ForEach(o => o.SetActive(true));
            }
            else
            {
                WonUI.ForEach(o => o.SetActive(true));
                BothUI.ForEach(o => o.SetActive(true));
                LostUI.ForEach(o => o.SetActive(false));
            }
        }
    }

    public void Retry()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
