using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestionBrick : MonoBehaviour
{
    public Animator brickAnimator;
    public AudioSource coinAudio;
    void Start()
    {
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
        brickAnimator.SetBool("collided", true);
        // play coinaudio after certain time
    }
}
