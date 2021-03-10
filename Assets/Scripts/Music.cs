using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Awake()
    {
        int musicCount = FindObjectsOfType<Music>().Length;
        if (musicCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyMusic() 
    {
        Destroy(gameObject);
    }
}
