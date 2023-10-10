using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject highscoreText;
    public IntVariable gameScore;


    // Start is called before the first frame update
    void Start()
    {
        SetHighscore();
    }

    void SetHighscore()
    {
        highscoreText.GetComponent<TextMeshProUGUI>().text = "TOP- " + gameScore.previousHighestValue.ToString("D6");
    }
    public void ResetHighscore()
    {
        GameObject eventSystem = GameObject.Find("EventSystem");
        eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        gameScore.ResetHighestValue();
        SetHighscore();

        // // reset cursor button state
        // eventSystem = GameObject.Find("EventSystem");
        // eventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
    }
    public void GoToLoadScene()
    {
        SceneManager.LoadSceneAsync("Loading Scene", LoadSceneMode.Single);
    }
}
