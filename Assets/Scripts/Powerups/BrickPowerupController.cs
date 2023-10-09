using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPowerupController : MonoBehaviour, PowerupControllerInterface
{
    public Boolean isBreakable;
    public Animator powerupAnimator;
    public Animator brickAnimator;
    public BasePowerup powerup;

    void Awake()
    {
        if (isBreakable)
        {
            brickAnimator.SetBool("break?", true);
        }
        else
        {
            brickAnimator.SetBool("break?", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !powerup.hasSpawned)
        {
            // spawn the powerup
            powerupAnimator.SetTrigger("spawned");
        }
    }
    // used by animator
    public void Disable()
    {
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        transform.localPosition = new Vector3(0, 0, 0);
    }
}
