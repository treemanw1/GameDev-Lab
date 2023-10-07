using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);
    // state
    [System.NonSerialized]
    public bool alive = true;
    public GameObject enemy;
    private float timer = 0.0f;

    void Awake()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    void Start()
    {
        Debug.Log(enemy.transform.position);
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
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
        // collide flatten goomba
    }
    public void GameRestart()
    {
        Debug.Log("Game restart!");
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        moveRight = -1;
        ComputeVelocity();
    }
    public void GoombaDeath()
    {
        //flatten
        transform.localScale = new Vector3(transform.localScale.x, .5f, transform.localScale.z);
        transform.localPosition = new Vector3(transform.position.x, transform.localPosition.y - .2f, transform.position.z);
        alive = false;
        enemy.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }
}