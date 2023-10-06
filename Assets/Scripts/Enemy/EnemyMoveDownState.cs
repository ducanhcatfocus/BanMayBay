using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveDownState : EnemyState
{

    public EnemyMoveDownState(Enemy _enemy, EnemyStateMachine _stateMachine) : base(_enemy, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.timeCd = 5;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                enemy.InstanciateEnemy(i, j);
            }
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(!enemy.EnemyMove(enemy.transform, enemy.transform.position, enemy.moveDownPos.position))
            enemy.timeCd -= Time.deltaTime;
        if (enemy.timeCd < 0)
            stateMachine.ChangeState(enemy.MoveDiamondState);

    }
}
