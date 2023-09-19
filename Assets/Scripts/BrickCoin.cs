using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCoin : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator brickAnimator;
    public AudioSource coinAudio;
    public Transform parentBrick;
    private bool collided = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.contacts[0].point.y - .3 < parentBrick.position.y - 0.5)
        {
            if (!collided)
            {
                brickAnimator.SetTrigger("firstCollide");
                collided = true;
                coinAudio.PlayDelayed(.3f);
            }
            else
            {
                brickAnimator.SetTrigger("subsequentCollide");
            }
        }
    }
}
