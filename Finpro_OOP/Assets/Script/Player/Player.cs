using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PauseMenu pauseMenu;
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    WeaponAttack wa;
    PlayerMovement pm;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wa = GetComponent<WeaponAttack>();
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wa.getCurWeapon() != null)
        {
            sr.sprite = sprite2;
        }
        else
        {
            sr.sprite = sprite1;
        }
    }
    public void GetKilled()
    {
        pauseMenu.GameOver();
        // sr.enabled = false;
        // rb.velocity = Vector2.zero;
        // rb.gravityScale = 0;
        // rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // gameObject.GetComponent<BoxCollider2D>().enabled = false;
        // pm.enabled = false;
        // wa.enabled = false;
    }
}
