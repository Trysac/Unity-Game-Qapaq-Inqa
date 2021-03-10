using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    [SerializeField] AudioClip artifact;
    [SerializeField] int pointsForArtifact = 300;

    bool isTaken = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isTaken == false)
            {
                isTaken = true;
                FindObjectOfType<GameSession>().AddToScore(pointsForArtifact);
                var camera = FindObjectOfType<MCamera>();
                AudioSource.PlayClipAtPoint(artifact, camera.transform.position);
                Destroy(gameObject);
            }
            
        }
    }
}
