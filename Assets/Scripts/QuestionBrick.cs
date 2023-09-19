using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestionBrick : MonoBehaviour
{
    public Animator brickAnimator;
    public AudioSource coinAudio;
    private bool collided = false;
    void Start()
    {
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
        if (!collided)
        {
            brickAnimator.SetTrigger("firstCollide");
            collided = true;
        }
    }
}
