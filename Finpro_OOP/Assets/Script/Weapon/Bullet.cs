using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;
public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    private Rigidbody2D rb;
    public IObjectPool<Bullet> objectPool;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.velocity = bulletSpeed * transform.up;
    }

    private void Update()
    {
        Vector2 ppos = Camera.main.WorldToViewportPoint(transform.position);

        if (ppos.y >= 5.01f || ppos.y <= -5.01f && objectPool != null)
        {
            objectPool.Release(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // Hit something and kill instanly
            other.gameObject.GetComponent<Enemy>().GetHit();
            Debug.Log("Hit: Another Object");
            objectPool.Release(this);
        }
        else if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Hit: Wall");
            objectPool.Release(this);
        }
    }
}
