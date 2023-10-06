using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    static GameManager instance;
    [SerializeField] int point = 0;

    public static GameManager Instance => instance;



    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 GameManager allow");
        instance = this;
    }


    public float GetPoint()
    {
        return point;
    }

    public void SetPoint()
    {
        point++;
        UIManager.Instance.UpdatePointUI(point);
    }
}
