
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype enemyPrefab;
    public Transform parent;
    public Transform moveDownPos;
    public Player player;
    [SerializeField] float timeCd = 5;
    [SerializeField] float speed = 2f;
    float objectWidth;
    float objectHeight;

    [SerializeField] List<Transform> enemyList = new List<Transform>();
    [SerializeField] List<Vector3> enemyDesPos = new List<Vector3>();


    void Start()
    {
        GetEnemySize();
        InstantiateEnemySquare();
        StartCoroutine(EnemyCoroutine());
    }

    private void GetEnemySize()
    {
        Renderer objectRenderer = enemyPrefab.GetComponent<Renderer>();
        Vector3 objectSize = objectRenderer.bounds.size;
        objectWidth = objectSize.x;
        objectHeight = objectSize.y;
    }

    IEnumerator EnemyCoroutine()
    {
        Vector3 direction = moveDownPos.position - transform.position;
        direction.Normalize();
        while (Vector3.Distance(transform.position, moveDownPos.position) >= 0.01f)
        {   
            transform.position += speed * Time.deltaTime * direction;
            yield return null;
        }
        yield return new WaitForSeconds(timeCd);
        while (!CheckALLEnemyMoveToDestination())
        {

            EnemyRhombus();
            yield return null;
        }
        yield return new WaitForSeconds(timeCd);
        enemyDesPos.Clear();
        while (!CheckALLEnemyMoveToDestination())
        {

            EnemyTriagle();
            yield return null;
        }
        yield return new WaitForSeconds(timeCd);
        enemyDesPos.Clear();
        while (!CheckALLEnemyMoveToDestination())
        {

            EnemyRectangle();
            yield return null;
        }
        EnemyCanTakeDamamge();
    }
    void InstantiateEnemySquare()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {

                EnemyPrototype newEnemy = Instantiate(enemyPrefab, parent);
                Vector3 newPosition = parent.transform.position + new Vector3(objectWidth * j, objectHeight * i, 0f);
                newEnemy.transform.position = newPosition;
                enemyList.Add(newEnemy.transform);
            }
        }
    }


    void EnemyRhombus()
    {
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if ((i != 0 && i != 4 && j != 0 && j != 5) || (i == 2 && (j == 0 || j == 5)))
                {
                    EnemyTransform(j, i, index, -1f);
                    index++;

                }
                if ((j == 2 && (i == 0 || i == 4)))
                {
                    EnemyTransform(j, i, index, -0.5f);
                    index++;
                }
            }
        }
    }

    void EnemyRectangle()
    {
        int index = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (i == 1 && (j == 0 || j == 6))
                {
                    EnemyTransform(j, i, index, -1.5f);
                    index++;

                }
                if (i != 1)
                {
                    EnemyTransform(j, i, index, -1.5f);
                    index++;
                }
            }
        }
    }

    void EnemyTriagle()
    {
        int index = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i == 0)
                {
                    EnemyTransform(j, i, index, -2.5f);
                    index++;
                }
                if (j == i && i != 0)
                {
                    EnemyTransform(j, i, index, -2.5f);
                    index++;
                }

                if (j == 8 - i && i != 0 && i != 4)
                {
                    EnemyTransform(j, i, index, -2.5f);
                    index++;
                }

            }
        }
    }

    void MoveBetweenTwoVector(Transform currentPos, Vector3 startPosition, Vector3 endPosition)
    {
        if (Vector3.Distance(currentPos.position, endPosition) <= 0.01f) return;
        Vector3 direction = endPosition - startPosition;
        direction.Normalize();
        currentPos.position += speed * Time.deltaTime * direction;
    }

    public void EnemyTransform(int j, int i, int index, float offset)
    {
        Vector3 newPosition = parent.transform.position + new Vector3(objectWidth * j + offset, objectHeight * i, 0f);
        if (enemyDesPos.Count < enemyList.Count)
            enemyDesPos.Add(newPosition);
        MoveBetweenTwoVector(enemyList[index].transform, enemyList[index].transform.position, newPosition);
    }


    bool CheckALLEnemyMoveToDestination()
    {
        if (enemyDesPos.Count != enemyList.Count) return false;
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (!(Vector3.Distance(enemyList[i].position, enemyDesPos[i]) <= 0.01f))
                return false;
        }

        return true;
    }

    void EnemyCanTakeDamamge()
    {
        player.isCanInflictDmg = true;
    }

}