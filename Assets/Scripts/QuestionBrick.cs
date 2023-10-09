using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class QuestionBrick : MonoBehaviour
{
    public Animator brickAnimator;
    public AudioSource coinAudio;
    public Transform parentBrick;
    private bool firstCollide = false;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].point.y - .3 < parentBrick.position.y - 0.5)
        {
            if (!firstCollide)
            {
                brickAnimator.SetTrigger("firstCollide");
                firstCollide = true;
                coinAudio.PlayDelayed(.3f);
            }
        }
    }
}
