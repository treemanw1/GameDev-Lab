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
    public BoolVariable marioFaceRight;
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
    int collisionLayerMask = (1 << 3) | (1 << 6) | (1 << 7) | (1 << 8) | (1 << 10);
    public Transform marioPosition;
    public UnityEvent<Vector3> goombaDeath;
    public UnityEvent incrementScore;
    public UnityEvent gameOver;
    private float timer = 0.0f;
    void Awake()
    {
        // GameManager.instance.gameRestart.AddListener(GameRestart);
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

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            timer += Time.deltaTime;
            if (timer >= .5f)
            {
                gameOver.Invoke();
            }
        }
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));
    }
    void FlipMarioSprite(int value)
    {
        if (value == -1 && faceRightState)
        {
            updateMarioShouldFaceRight(false);
            marioSprite.flipX = !faceRightState;
            if (marioBody.velocity.x > 0.05f)
                marioAnimator.SetTrigger("onSkid");
        }

        else if (value == 1 && !faceRightState)
        {
            updateMarioShouldFaceRight(true);
            marioSprite.flipX = !faceRightState;
            if (marioBody.velocity.x < -0.05f)
                marioAnimator.SetTrigger("onSkid");
        }
    }
    private void updateMarioShouldFaceRight(bool value)
    {
        faceRightState = value;
        marioFaceRight.SetValue(faceRightState);
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
            if (marioPosition.position.y - GetComponent<BoxCollider2D>().bounds.extents.y > other.transform.position.y)
            {
                incrementScore.Invoke();
                goombaDeath.Invoke(other.transform.position);
            }
            else
            {
                alive = false;
                // marioAnimator.Play("mario-die");
                marioDeathAudio.PlayOneShot(marioDeathAudio.clip);
                // gameOver.Invoke();
                DamageMario();
            }
        }
    }
    public void DamageMario()
    {
        GetComponent<MarioStateController>().SetPowerup(PowerupType.Damage);
    }
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
        timer = 0f;
        onGroundState = true;
        marioAnimator.SetBool("onGround", true);
        // reset camera position
        // gameCamera.transform.position = new Vector3(0, 0, -10);
    }
    void PlayJumpSound()
    {
        marioAudio.PlayOneShot(marioAudio.clip);
    }
    void PlayDeathImpulse()
    {
        marioBody.AddForce(Vector2.up * 30, ForceMode2D.Impulse);
    }
}