using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    [SerializeField] AudioClip coin;
    [SerializeField] int pointsForCoin = 100;

    bool isTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if (isTaken == false) 
            {
                isTaken = true;
                FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
                var camera = FindObjectOfType<MCamera>();
                AudioSource.PlayClipAtPoint(coin, camera.transform.position);
                Destroy(gameObject);
            }
            
        }
        
    }
}
