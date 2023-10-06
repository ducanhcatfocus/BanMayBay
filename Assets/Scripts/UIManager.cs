using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    static UIManager instance;

    public static UIManager Instance => instance;


    public TextMeshProUGUI pointText;

    private void Awake()
    {
        if (instance != null) Debug.LogError("Only 1 UIManager allow");

        instance = this;
    }


    public void UpdatePointUI(int value)
    {
        pointText.text = value.ToString();
    }

}
