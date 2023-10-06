using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTriangleState : EnemyState
{
   
    public EnemyMoveTriangleState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.timeCd = 5;

        enemy.enemyDesPos.Clear();
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
            stateMachine.ChangeState(enemy.MoveRectangleState);
    }

    void Move()
    {
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == 0)
                {
                    enemy.EnemyTransform(j, i, index, -2.5f);

                    index++;
                }
                if (j == i && i != 0)
                {
                    enemy.EnemyTransform(j, i, index, -2.5f);

                    index++;
                }

                if (j == 8 - i && i != 0 && i != 4)
                {
                    enemy.EnemyTransform(j, i, index, -2.5f);

                    index++;
                }

            }
        }

    }
}
