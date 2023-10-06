using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Enemy enemy;

    public EnemyState(Enemy _enemy, EnemyStateMachine _stateMachine)
    {
        this.stateMachine = _stateMachine;
        this.enemy = _enemy;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {

    }
}
