using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite alive;
    [SerializeField] Sprite dead;
    [SerializeField] Transform target;

    NavMeshAgent agent;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Vector2 moveDir;
    bool isChasing = false;
    bool isDead = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        moveDir = new Vector2(0, 0);
    }
    // Update is called once per frame
    void Update()
    {
        ChasePlayer(isChasing, isDead);
        DetectPlayer();
    }
    public void GetHit()
    {
        sr.sprite = dead;
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        agent.isStopped = true;
        isDead = true;
        // Destroy(gameObject, 1.0f);
    }
    void ChasePlayer(bool chase, bool dead)
    {
        if(chase && !dead)
        {
            agent.SetDestination(target.position);
            moveDir = target.position - transform.position;
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }
    void DetectPlayer()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        if(distance < 10 && target.gameObject.GetComponent<WeaponAttack>().getIsShooting() == true)
        {
            isChasing = true;
        }
        else if(distance < 2.5f)
        {
            isChasing = true;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Player>().GetKilled();
        }
    }
}
