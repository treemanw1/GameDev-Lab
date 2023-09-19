using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Animator brickAnimator;
    public Transform parentBrick;
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
        if (col.contacts[0].point.y - .3 < parentBrick.position.y - 0.5)
        {
            brickAnimator.SetBool("collided", true);
        }
    }
}
