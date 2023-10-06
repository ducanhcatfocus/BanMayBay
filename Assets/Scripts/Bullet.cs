using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int movespeed = 9;
    [SerializeField] int damage = 1;
    [SerializeField] float bulletLifeTime = 10;

    public bool isCanInflictDmg = false;
 

    void Update()
    {
        transform.Translate(movespeed * Time.deltaTime * Vector3.up);
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime < 0)
        {
            gameObject.SetActive(false);

        }
    }

    public void ResetElapsedTime()
    {
        bulletLifeTime = 10f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isCanInflictDmg) return;

        if (collision.CompareTag("Enemy"))
        {
            EnemyPrototype enemy = collision.GetComponent<EnemyPrototype>();
            int healh = enemy.GetEnemyHealh();
            if (healh-damage <= 0)
            {
                Destroy(enemy.gameObject);
                GameManager.Instance.SetPoint();
                return;
            }
            enemy.SetEnemyHealh(healh - damage);
            gameObject.SetActive(false);
       
        }
    }
}
