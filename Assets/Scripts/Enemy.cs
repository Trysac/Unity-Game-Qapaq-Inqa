using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidBody;
    Animator myAnimator;

    [SerializeField] float life = 150f;
    [SerializeField] int pointsPerDeath = 30;

    bool isDeath = false;

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        EnemyDeath();

        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Arrow"))
        {
            this.transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        }
    }

    private void EnemyDeath()
    {
        if (life <= 0 && isDeath == false)
        {
            FindObjectOfType<GameSession>().AddToScore(pointsPerDeath);
            myAnimator.SetTrigger("Death");
            isDeath = true;
            Destroy(gameObject, 0.3f);
        }
        else { return; }
    }

    public void EnemyHit(float damage)
    {
        life -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            var arrow = FindObjectOfType<Arrow>();
            EnemyHit(arrow.GetArrowDamage());
            Destroy(collision.gameObject);
        }
    }
}
