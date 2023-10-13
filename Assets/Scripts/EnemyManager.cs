using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public AudioSource deathAudio;
    void Start()
    {
        GameManager.instance.gameRestart.AddListener(GameRestart);
    }
    public void GameRestart()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<EnemyMovement>().GameRestart();
        }
    }

    public void GoombaDeath(Vector3 position)
    {
        foreach (Transform child in transform)
        {
            if (child.position.x == position.x)
            {
                child.GetComponent<BoxCollider2D>().enabled = false;
                child.localScale = new Vector3(child.localScale.x, .5f, child.localScale.z);
                child.localPosition = new Vector3(child.localPosition.x, child.localPosition.y - .25f, child.localPosition.z);
                deathAudio.PlayOneShot(deathAudio.clip);
                child.gameObject.GetComponent<EnemyMovement>().Die();
                child.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                break;
            }
        }
    }
}
