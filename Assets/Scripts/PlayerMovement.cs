using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10;
    public float maxSpeed = 20;
    public float upSpeed = 10;
    private bool onGroundState = true;
    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private bool faceRightState = true;
    public GameObject scoreText;
    public GameObject enemies;
    public JumpOverGoomba jumpOverGoomba;
    public GameObject DeathOverlay;
    public TextMeshProUGUI finalScoreText;
    public GameObject restartButton;
    public Animator marioAnimator;
    public AudioSource marioAudio;
    public AudioSource marioDeathAudio;
    // state
    [System.NonSerialized]
    public bool alive = true;
    private bool moving = false;
    private bool jumpedState = false;
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 << 8);
    public GameObject gameCamera;
    public Transform marioPosition;
    public GameManager gameManager;
    public UnityEvent goombaDeath;
    // Start is called before the first frame update
    void Start()
    {
        marioSprite = GetComponent<SpriteRenderer>();
        // Set to be 30 FPS
        Application.targetFrameRate = 30;
        marioBody = GetComponent<Rigidbody2D>();
        marioAnimator.SetBool("onGround", onGroundState);
    }

    // public void RestartButtonCallback(int input)
    // {
    //     Debug.Log("Restart");
    //     // reset everything
    //     ResetGame();
    //     // resume time
    //     Time.timeScale = 1.0f;
    // }

    // private void ResetGame()
    // {
    //     // reset position
    //     marioBody.transform.position = new Vector3(-2f, -1f, 0.0f);
    //     // reset sprite direction
    //     faceRightState = true;
    //     marioSprite.flipX = false;
    //     // reset score
    //     scoreText.text = "Score: 0";
    //     // reset Goomba
    //     foreach (Transform eachChild in enemies.transform)
    //     {
    //         eachChild.transform.localPosition = eachChild.GetComponent<EnemyMovement>().startPosition;
    //     }
    //     jumpOverGoomba.score = 0;
    //     // remove Game Over page
    //     DeathOverlay.gameObject.SetActive(false);
    //     scoreText.enabled = true;
    //     restartButton.gameObject.SetActive(true);
    //     // reset animation
    //     marioAnimator.SetTrigger("gameRestart");
    //     alive = true;
    // }

    public void GameRestart()
    {
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
                gameManager.IncreaseScore(1);
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
        DeathOverlay.gameObject.SetActive(true);
        scoreText.SetActive(false);
        restartButton.gameObject.SetActive(false);
        finalScoreText.text = jumpOverGoomba.scoreText.text;
    }
}