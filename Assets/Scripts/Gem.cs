using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] AudioClip gem;
    [SerializeField] int pointsForGem = 500;

    bool isTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isTaken == false) 
            {
                isTaken = true;
                FindObjectOfType<GameSession>().AddToScore(pointsForGem);
                var camera = FindObjectOfType<MCamera>();
                AudioSource.PlayClipAtPoint(gem, camera.transform.position);
                Destroy(gameObject);
            }

            
        }
    }
}
