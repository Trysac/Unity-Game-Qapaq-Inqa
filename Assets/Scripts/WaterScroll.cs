using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScroll : MonoBehaviour
{
    [SerializeField] float scrollRate = 0.14f;

    void Update()
    {
        float yMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMove));
    }
}
