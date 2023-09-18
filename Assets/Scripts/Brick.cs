using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private Rigidbody2D brickBody;
    private SpringJoint2D brickSpringJoint;
    public GameObject coin;
    private Vector3 coinVector;
    private bool collided = false;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        brickBody = GetComponent<Rigidbody2D>();
        brickSpringJoint = GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetType() == coin.GetType())
        {
            if (!collided)
            {
                coinVector = transform.parent.position;
                coinVector.z = 1;
                coinVector.y = 0.3f;
                Instantiate(coin, coinVector, transform.parent.rotation);
                collided = true;
            }
            else
            {
                // disable brick movement
                brickBody.bodyType = RigidbodyType2D.Static;
                brickSpringJoint.enabled = false;
                // play sound here
                coinAudio.PlayOneShot(coinAudio.clip);
            }
        }
    }
}
