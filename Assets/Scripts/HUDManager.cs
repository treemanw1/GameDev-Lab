using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    private Vector3[] scoreTextPosition = {
        new Vector3(-827, 472, 0),
        new Vector3(0, 0, 0)
        };
    private Vector3[] restartButtonPosition = {
        new Vector3(868, 444, 0),
        new Vector3(0, -179, 0)
    };

    public GameObject scoreText;
    public GameObject restartButton;

    public GameObject deathOverlay;
    void Awake()
    {
        // subscribe to events
        GameManager.instance.gameStart.AddListener(GameStart);
        GameManager.instance.gameOver.AddListener(GameOver);
        GameManager.instance.gameRestart.AddListener(GameStart);
        GameManager.instance.scoreChange.AddListener(SetScore);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        // hide gameover panel
        deathOverlay.SetActive(false);
        scoreText.SetActive(true);
        restartButton.SetActive(true);
        // scoreText.transform.localPosition = scoreTextPosition[0];
        // restartButton.localPosition = restartButtonPosition[0];
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }


    public void GameOver()
    {
        deathOverlay.SetActive(true);
        scoreText.SetActive(false);
        restartButton.SetActive(false);
        // scoreText.transform.localPosition = scoreTextPosition[1];
        // restartButton.localPosition = restartButtonPosition[1];
    }
}
