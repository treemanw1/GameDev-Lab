using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Vector3 startPosition;
    // state
    [System.NonSerialized]
    public bool alive = true;
    public GameObject enemy;
    private float timer = 0.0f;
    public Vector3 ogLocalscale;
    public SimpleGameEvent damagePlayer;
    public IntGameEvent incrementScore;
    public UnityEvent<Vector3> goombaDeath;
    public UnityEvent<Vector3> goombaFireballDeath;
    void Awake()
    {
        ogLocalscale = transform.localScale;
        startPosition = transform.position;
    }
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
        // GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (alive)
        {
            if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
            {// move goomba
                Movegoomba();
            }
            else
            {
                // change direction
                moveRight *= -1;
                ComputeVelocity();
                Movegoomba();
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= 1.5f)
            {
                enemy.SetActive(false);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.transform.position.y - other.gameObject.GetComponent<BoxCollider2D>().bounds.extents.y > transform.position.y)
            {
                Debug.Log("Collide top!");
                incrementScore.Raise(1);
                goombaDeath.Invoke(transform.position);
            }
            else
            {
                Debug.Log("Collide side!");
                damagePlayer.Raise(this);
            }
        }
        else if (other.gameObject.CompareTag("Fireball"))
        {
            incrementScore.Raise(1);
            goombaFireballDeath.Invoke(transform.position);
        }
    }
    public void GameRestart()
    {
        enemy.SetActive(true);
        alive = true;
        GetComponent<BoxCollider2D>().enabled = true;
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        transform.localScale = ogLocalscale;
        moveRight = -1;
        timer = 0.0f;
        ComputeVelocity();
    }
    public void Die()
    {
        alive = false;
    }
}