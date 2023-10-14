using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBrickPowerupController : MonoBehaviour, PowerupControllerInterface
{
    public Animator powerupAnimator;
    public BasePowerup powerup; // reference to this question box's powerup
    public Transform parentBrick;

    void Start()
    {
        // GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !powerup.hasSpawned && other.contacts[0].point.y - .3 < parentBrick.position.y - 0.5)
        {
            powerupAnimator.SetTrigger("spawned"); //SpawnPowerup()
        }
    }
    // used by animator
    public void Disable()
    {
        // this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // transform.localPosition = new Vector3(0, 0, 0);
    }
    public void GameRestart()
    {
    }
}