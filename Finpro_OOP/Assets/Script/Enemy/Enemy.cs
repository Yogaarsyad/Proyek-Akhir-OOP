using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite alive;
    [SerializeField] Sprite dead;
    SpriteRenderer sr;
    Rigidbody2D rb;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetHit()
    {
        sr.sprite = dead;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        // Destroy(gameObject, 1.0f);
    }
}
