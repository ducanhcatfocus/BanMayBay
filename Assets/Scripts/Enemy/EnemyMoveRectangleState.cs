using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRectangleState : EnemyState
{

    
    public EnemyMoveRectangleState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.timeCd = 2;

        enemy.enemyDesPos.Clear();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.timeCd < 0)
        {
            enemy.EnemyCanTakeDamamge();
            return;
        }
            

        if (enemy.CheckALLEnemyMoveToDestination())
        {
                enemy.timeCd -= Time.deltaTime;

        }
        else
        {
            Move();
        }

    }

    void Move()
    {
        int index = 0;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == 1 && (j==0 || j==6) )
                {
                    enemy.EnemyTransform(j, i, index, -1.5f);
                    index++;
                   
                }
                if (i != 1)
                {
                    enemy.EnemyTransform(j, i, index, -1.5f);
                    index++;
                }
            }
        }

    }
}
