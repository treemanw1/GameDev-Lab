using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D coinBody;

    // Start is called before the first frame update
    void Start()
    {
        coinBody = GetComponent<Rigidbody2D>();
        coinBody.AddForce(Vector2.up * .06f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
