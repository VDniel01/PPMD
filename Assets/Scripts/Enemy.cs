using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3;
    public float speed = 5f;
    private float originalSpeed;
    private bool isSlowed = false;

    protected virtual void Start()
    {
        originalSpeed = speed;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void ApplySlow(float slowAmount, float duration)
    {
        if (!isSlowed)
        {
            speed *= (1f - slowAmount);
            isSlowed = true;
            Invoke("RemoveSlow", duration);
        }
    }

    void RemoveSlow()
    {
        speed = originalSpeed;
        isSlowed = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
