using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{

    public float timeCd = 5f;
    public float speed = 2f;
    public bool isMove;


    public List<Transform> enemyList = new List<Transform>();
    public List<Vector3> enemyDesPos = new List<Vector3>();
    float objectWidth;
    float objectHeight;
    


    public EnemyPrototype enemyPrefab;
    public Player player;
    public Transform parent;
    public Transform moveDownPos;


    public EnemyStateMachine StateMachine {  get; private set; }
    public EnemyMoveDownState MoveDownState { get; private set; }
    public EnemyMoveDiamondState MoveDiamondState { get; private set;}
    public EnemyMoveTriangleState MoveTriangleState { get; private set; }
    public EnemyMoveRectangleState MoveRectangleState { get; private set; }

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        MoveDownState = new EnemyMoveDownState(this, StateMachine);
        MoveDiamondState = new EnemyMoveDiamondState(this, StateMachine);
        MoveTriangleState = new EnemyMoveTriangleState(this, StateMachine);
        MoveRectangleState = new EnemyMoveRectangleState(this, StateMachine);
  
    }

    private void Start()
    {
        Renderer objectRenderer = enemyPrefab.GetComponent<Renderer>();
        Vector3 objectSize = objectRenderer.bounds.size;
        objectWidth = objectSize.x;
        objectHeight = objectSize.y;

     
        StateMachine.Initialize(MoveDownState);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }

    public void InstanciateEnemy(int j, int i)
    {
        EnemyPrototype newEnemy = Instantiate(enemyPrefab, parent);
        Vector3 newPosition = parent.transform.position + new Vector3(objectWidth * j, objectHeight * i, 0f);
        newEnemy.transform.position = newPosition;
        enemyList.Add(newEnemy.transform);
    }

    public bool EnemyMove(Transform currentPos, Vector3 startPosition, Vector3 endPosition)
    {
        if (Vector3.Distance(currentPos.position, endPosition) <= 0.05f)
        {
            return false; 
        }

        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        currentPos.position += speed * Time.deltaTime * direction;
        return true;
    }

    public void EnemyTransform(int j, int i, int index, float offset)
    {
        Vector3 newPosition = parent.transform.position + new Vector3(objectWidth * j + offset , objectHeight * i, 0f);
        if (enemyDesPos.Count < enemyList.Count)
        {
            enemyDesPos.Add(newPosition);

        }
        EnemyMove(enemyList[index].transform, enemyList[index].transform.position, newPosition);
    }

    public bool CheckALLEnemyMoveToDestination()
    {
        if (enemyDesPos.Count != enemyList.Count) return false;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!(Vector3.Distance(enemyList[i].position, enemyDesPos[i]) <= 0.05f))
            {
                return false;
            }
        }

        return true;
    }

    public void EnemyCanTakeDamamge()
    {
        player.isCanInflictDmg = true;
    }


}
