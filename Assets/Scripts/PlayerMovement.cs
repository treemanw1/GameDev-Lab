using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameConstants gameConstants;
    float deathImpulse;
    float upSpeed;
    float maxSpeed;
    float speed;


    // public float speed = 10;
    private Rigidbody2D marioBody;
    // public float maxSpeed = 20;
    // public float upSpeed = 10;
    private bool onGroundState = true;
    private bool jumpedState = false;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    private bool moving = false;
    // public float deathImpulse = 45;
    public GameObject gameCamera;
    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioSource marioDeathAudio;
    [System.NonSerialized]
    public bool alive = true;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 << 8);
    public Transform marioPosition;
    public UnityEvent goombaDeath;
    void Awake()
    {
        // subscribe to Game Restart event
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Set constants
        speed = gameConstants.speed;
        maxSpeed = gameConstants.maxSpeed;
        deathImpulse = gameConstants.deathImpulse;
        upSpeed = gameConstants.upSpeed;

        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();

        // update animator state
        marioAnimator.SetBool("onGround", onGroundState);
        // SceneManager.activeSceneChanged += SetStartingPosition;
    }
    public void SetStartingPosition(Scene current, Scene next)
    {
        if (next.name == "World 1-2")
        {
            // change the position accordingly in your World-1-2 case
            transform.position = new Vector3(-6, -3.5f, 0.0f);
        }
    }
    public void GameRestart()
    {
        Debug.Log("callback invoked");
        // reset position
        marioBody.transform.position = new Vector3(-5.33f, -4.69f, 0.0f);
        // reset sprite direction
        faceRightState = true;
        marioSprite.flipX = false;

        // reset animation
        marioAnimator.SetTrigger("gameRestart");
        alive = true;

        // reset camera position
        gameCamera.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
    }

    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            faceRightState = false;
            marioSprite.flipX = true;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");
        }

        else if (value == 1 && !faceRightState)
        {
            faceRightState = true;
            marioSprite.flipX = false;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (((collisionLayerMask & (1 << col.transform.gameObject.layer)) > 0) & !onGroundState)
        {
            onGroundState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    // FixedUpdate is called 50 times a second
    // FixedUpdate may be called once per frame. See documentation for details.
    void FixedUpdate()
    {
        if (alive && moving)
        {
            Move(faceRightState == true ? 1 : -1);
        }
    }
    void Move(int value)
    {
        Vector2 movement = new Vector2(value, 0);
        // check if it doesn't go beyond maxSpeed
        if (marioBody.velocity.magnitude < maxSpeed)
            marioBody.AddForce(movement * speed);
    }

    public void MoveCheck(int value)
    {
        if (value == 0)
        {
            moving = false;
        }
        else
        {
            FlipMarioSprite(value);
            moving = true;
            Move(value);
        }
    }
    public void Jump()
    {
        if (alive && onGroundState)
        {
            // jump
            marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
            onGroundState = false;
            jumpedState = true;
            // update animator state
            marioAnimator.SetBool("onGround", onGroundState);

        }
    }
    public void JumpHold()
    {
        if (alive && jumpedState)
        {
            // jump higher
            marioBody.AddForce(Vector2.up * upSpeed * 30, ForceMode2D.Force);
            jumpedState = false;

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && alive)
        {
            // if collide top
            if (marioPosition.position.y > other.transform.position.y + 0.2f)
            {
                // call function in EnemyMovement (flatten + remove corpse)
                GameManager.instance.IncreaseScore(1);
                goombaDeath.Invoke();
            }
            else
            {
                marioAnimator.Play("mario-die");
                marioDeathAudio.PlayOneShot(marioDeathAudio.clip);
                alive = false;
            }
        }
    }
    void PlayJumpSound()
    {
        marioAudio.PlayOneShot(marioAudio.clip);
    }
    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * 15, ForceMode2D.Impulse);
    }
    void GameOverScene()
    {
        alive = false;
        GameManager.instance.GameOver();
    }
}