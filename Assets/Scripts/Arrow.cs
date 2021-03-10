using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 50f;

    Player ArcSide;
    bool alreadyFired = false;

    void Start()
    {
        ArcSide = FindObjectOfType<Player>();
        float side = ArcSide.GetShootSide();
        transform.localScale = new Vector2(side, 1);
        alreadyFired = true;

        Invoke("DestroyArrow", 2f);
    }

    void Update()
    {
        if (alreadyFired)
        {
            if (transform.localScale.x > 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else if (transform.localScale.x < 0)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime * -1);
            }
        }
    }
    public float GetArrowDamage()
    {
        return damage;
    }
    public void DestroyArrow()
    {
        Destroy(gameObject);
    }

}
