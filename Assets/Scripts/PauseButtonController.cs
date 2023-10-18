
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour, InteractiveButton
{
    private bool isPaused = false;
    public Sprite pauseIcon;
    public Sprite playIcon;
    private Image image;
    public GameObject pauseOverlay;
    public SimpleGameEvent gamePaused;
    public SimpleGameEvent gameResumed;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ButtonClick()
    {
        Time.timeScale = isPaused ? 1.0f : 0.0f;
        isPaused = !isPaused;
        if (isPaused)
        {
            image.sprite = playIcon;
            pauseOverlay.SetActive(true);
            gamePaused.Raise(this);
        }
        else
        {
            image.sprite = pauseIcon;
            pauseOverlay.SetActive(false);
            gameResumed.Raise(this);
        }
    }
}
