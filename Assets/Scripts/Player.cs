using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Vector3 worldPos;
    [SerializeField] float  speed = 0.1f;
    [SerializeField] float shotCdTime = 0.1f;
    [SerializeField] float timeBetweenShoot = 0.1f;
    public Transform shotPos;
    public Bullet bulletPrefab;
    public bool isCanInflictDmg = false;
    void Start()
    {
        
    }

    private void Update()
    {
        shotCdTime -= Time.deltaTime;
        Shot();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;
        Vector3 newPos = Vector3.Lerp(transform.position, worldPos, speed);
        transform.position = newPos;
    }

    void Shot()
    {
        if (shotCdTime < 0 && Input.GetAxis("Fire1") ==1)
        {
            Bullet newBullet = BulletPooling.Instance.GetBullet();
            newBullet.transform.position = shotPos.position;
           shotCdTime = timeBetweenShoot;
           newBullet.isCanInflictDmg = isCanInflictDmg;
        }
    }



}
