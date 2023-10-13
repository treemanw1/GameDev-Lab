
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMushroomPowerup : BasePowerup
{
    private Vector3 ogPowerupPos;
    private Vector3 ogMushroomPos;
    public Animator powerupAnimator;
    void Awake()
    {
        ogPowerupPos = transform.position;
        ogMushroomPos = ogPowerupPos;
    }
    protected override void Start()
    {
        base.Start(); // call base class Start()
        powerupAnimator.ResetTrigger("reset");
        this.type = PowerupType.MagicMushroom;
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 3)
        {
            Debug.Log(col.gameObject.name);
        }
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player
            gameObject.SetActive(false);
            spawned = false;
            Debug.Log("Make mario big");
        }
        else if (col.gameObject.layer == 10) // else if hitting Pipe, flip travel direction
        {
            if (spawned)
            {
                goRight = !goRight;
                rigidBody.AddForce(Vector2.right * 3 * (goRight ? 1 : -1), ForceMode2D.Impulse);
            }
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spawned = true;
        rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
    }


    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
        // TODO: do something with the object
    }
    public void GameRestart()
    {
        gameObject.SetActive(true);
        transform.position = ogMushroomPos;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // powerupAnimator.SetTrigger("reset");
        powerupAnimator.Play("idle");
        spawned = false;
    }
}