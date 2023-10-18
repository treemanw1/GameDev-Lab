using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPowerup : BasePowerup
{
    private Vector3 ogPowerupPos;
    private Vector3 ogStarPos;
    public Animator powerupAnimator;
    // public MarioStateController mario;
    public PowerupGameEvent powerupCollected;
    void Awake()
    {
        ogPowerupPos = transform.position;
        ogStarPos = ogPowerupPos;
    }
    protected override void Start()
    {
        base.Start(); // call base class Start()
        powerupAnimator.Play("idle");
        this.type = PowerupType.StarMan;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && spawned)
        {
            // TODO: do something when colliding with Player
            // gameObject.SetActive(false);
            transform.position = new Vector3(1000, 0, 0);
            spawned = false;
            powerupCollected.Raise(this);
        }
    }

    // interface implementation
    public override void SpawnPowerup()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        spawned = true;
        // rigidBody.AddForce(Vector2.right * 3, ForceMode2D.Impulse); // move to the right
    }

    // interface implementation
    public override void ApplyPowerup(MonoBehaviour i)
    {
    }
    public void GameRestart()
    {
        gameObject.SetActive(true);
        transform.position = ogStarPos;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // powerupAnimator.SetTrigger("reset");
        powerupAnimator.Play("idle");
        spawned = false;
    }
}
