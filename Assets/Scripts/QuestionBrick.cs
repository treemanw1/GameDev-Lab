using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestionBrick : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D brickBody;
    private SpringJoint2D brickSpringJoint;
    public Animator brickAnimator;
    public GameObject coin;
    private Vector3 coinVector;
    private bool collided = false;
    public AudioSource coinAudio;
    void Start()
    {
        brickBody = GetComponent<Rigidbody2D>();
        brickSpringJoint = GetComponent<SpringJoint2D>();
        brickAnimator.SetBool("collided", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collided");
        brickAnimator.SetBool("collided", true);
        // if (col.gameObject.GetType() == coin.GetType())
        // {
        //     if (!collided)
        //     {
        //         coinVector = transform.parent.position;
        //         coinVector.z = 1;
        //         coinVector.y = 0.3f;
        //         Instantiate(coin, coinVector, transform.parent.rotation);
        //         collided = true;
        //         brickAnimator.SetBool("collided", true);
        //     }
        //     else
        //     {
        //         // disable brick movement
        //         brickBody.bodyType = RigidbodyType2D.Static;
        //         brickSpringJoint.enabled = false;
        //         // play sound here
        //         coinAudio.PlayOneShot(coinAudio.clip);
        //     }
        // }
    }
}
