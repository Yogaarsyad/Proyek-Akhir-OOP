using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;
    WeaponAttack wa;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        wa = GetComponent<WeaponAttack>();
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
}
