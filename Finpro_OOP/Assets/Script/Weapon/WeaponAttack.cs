using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Pool;

public class WeaponAttack : MonoBehaviour
{
    GameObject curWeapon;
    bool gun = false;
    float timer = 0.1f, reset = 0.1f;
    float weaponChange = 0.5f;
    bool canChange = true;
    // ObjectPool for Bullets
    [Header("Bullets")]
    public Bullet bullet;
    [SerializeField] private Transform bulletSpawnPoint;


    [Header("Bullet Pool")]
    private IObjectPool<Bullet> objectPool;

    private readonly bool collectionCheck = false;
    private readonly int defaultCapacity = 30;
    private readonly int maxSize = 100;
    public Transform parentTransform;
    private int magSize = 15;
    [SerializeField] private int curMagSize = 15;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(bulletSpawnPoint);
        objectPool = new ObjectPool<Bullet>(CreateBullet, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject, collectionCheck, defaultCapacity, maxSize);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetMouseButtonDown(0));
        Debug.Log(Input.GetMouseButtonDown(1));
        Debug.Log("Current Weapon Exist:" + curWeapon);
        if(Input.GetMouseButtonDown(0) && curWeapon != null)
        {
            Attack();
        }
        if(Input.GetMouseButtonDown(1))
        {
            if(canChange == false && curWeapon != null)
            {
                DropWeapon();
            }
        }
        if(Input.GetKeyDown(KeyCode.R) && curWeapon != null)
        {
            StartCoroutine(reload(1.5f));
        }
        if(canChange)
        {
            weaponChange -= Time.deltaTime;
            if(weaponChange <= 0)
            {
                canChange = false;
            }
        }
    }
    public void setWeapon(GameObject weapon, string name, float fireRate, bool gun)
    {
        canChange = true;
        curWeapon = weapon;
        this.gun = gun;
        this.reset = fireRate;
        this.timer = reset;
    }
    void Attack()
    {
        //shoot if gun
        if (gun && curMagSize > 0)
        {
            Bullet bulletObj = objectPool.Get();
            bulletObj.transform.SetPositionAndRotation(bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            curMagSize--;
        }
    }
    public GameObject getCurWeapon()
    {
        return curWeapon;
    }
    public void DropWeapon()
    {
        curWeapon.transform.position = this.transform.position;
        curWeapon.SetActive(true);
        setWeapon(null, "", 0, false);
    }
    IEnumerator reload(float delay)
    {
        curMagSize = 0;
        yield return new WaitForSeconds(delay);
        curMagSize = magSize;
    }
    //Object pool methods
        private Bullet CreateBullet()
    {
        Bullet instance = Instantiate(bullet);
        instance.objectPool = objectPool;
        instance.transform.parent = transform;

        return instance;
    }

    private void OnGetFromPool(Bullet obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Bullet obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObject(Bullet obj)
    {
        Destroy(obj.gameObject);
    }
}
