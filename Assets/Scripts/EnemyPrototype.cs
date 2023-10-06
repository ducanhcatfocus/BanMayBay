using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrototype : MonoBehaviour
{
    [SerializeField] int enemyHealh = 5;

    public int GetEnemyHealh()
    { return enemyHealh; }

    public void SetEnemyHealh(int value)
    { enemyHealh = value; }



}
