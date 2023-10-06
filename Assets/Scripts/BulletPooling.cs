using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    private static BulletPooling instance;
    public static BulletPooling Instance => instance;

    public List<Bullet> bulletPool = new List<Bullet>();
    public Bullet bulletPrefab;


    private void Awake()
    {

       
        if(instance != null ) Debug.LogError("Only 1 Pooling allow");
        instance = this;

        
    }


    public Bullet GetBullet()
    {
        Bullet target = null;
        foreach (var bullet in bulletPool)
        {
            if (!bullet.gameObject.activeSelf)
            {
                target = bullet; break;
            }
        }

        if (target == null)
        {
            target = CreatBulletIfNone();
        }
        target.ResetElapsedTime();
        target.gameObject.SetActive(true);
        return target;
    }

    private Bullet CreatBulletIfNone()
    {
        Bullet bullet = Instantiate(bulletPrefab, transform);
        bulletPool.Add(bullet);
        return bullet;
    }
}