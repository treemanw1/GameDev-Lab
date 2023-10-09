using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBrickPowerupController : MonoBehaviour, PowerupControllerInterface
{
    public Animator powerupAnimator;
    public BasePowerup powerup; // reference to this question box's powerup
    public Transform parentBrick;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !powerup.hasSpawned && other.contacts[0].point.y - .3 < parentBrick.position.y - 0.5)
        {
            // spawn the powerup
            powerupAnimator.SetTrigger("spawned");
            // enable powerup hitbox
        }
    }
    // used by animator
    public void Disable()
    {
        // this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // transform.localPosition = new Vector3(0, 0, 0);
    }
}