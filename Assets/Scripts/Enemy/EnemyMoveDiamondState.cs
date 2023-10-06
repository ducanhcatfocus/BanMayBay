using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDiamondState : EnemyState
    
{
   


    public EnemyMoveDiamondState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.timeCd = 5;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.CheckALLEnemyMoveToDestination())
        {
            enemy.timeCd -= Time.deltaTime;

        }
        else
        {
            Move();

        }
        if (enemy.timeCd < 0)
        {
     
            stateMachine.ChangeState(enemy.MoveTriangleState);

        }
    }

    void Move()
    {
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if ((i != 0 && i != 4 && j != 0 && j != 5) || (i == 2 && (j == 0 || j == 5)))
                {
                    enemy.EnemyTransform(j, i, index, -1f);
                    index++;

                }
                if ((j == 2 && (i == 0 || i == 4)))
                {
                    enemy.EnemyTransform(j, i, index, -0.5f);
                    index++;
                }
            }
        } 
        
    }
}
