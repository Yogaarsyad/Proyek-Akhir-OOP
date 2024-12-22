using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public string weaponName;
    public float fireRate;
    WeaponAttack wa;
    // WeaponAttack wa;
    public bool gun;

    // Start is called before the first frame update
    void Start()
    {
        wa = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("Player Collision");
        Debug.Log(Input.GetMouseButtonDown(1));
        if(coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            Debug.Log("Player Picked Up" + weaponName);
            if(wa.getCurWeapon() != null)
            {
                wa.DropWeapon();
            }
            wa.setWeapon(this.gameObject, weaponName, fireRate, gun);
            gameObject.SetActive(false);
        }
    }
}
