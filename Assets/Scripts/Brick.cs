using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Animator brickAnimator;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        brickAnimator.SetBool("collided", false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collidededed");
        brickAnimator.SetBool("collided", true);
    }
}
