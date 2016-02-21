using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    AutoGridLayout grid;
    [SerializeField]
    GameObject cell;

    private GameObject cellClone;
    Dictionary<int, int> cellArray = new Dictionary<int, int>();

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        GenerateGrid(5);
    }

    void GenerateGrid(int columnCount)
    {

        grid.m_Column = columnCount;

        for (var i = 1; i <= columnCount; i++)
        {
            for(var j = 1; j <= columnCount; j++)
            {
                cellClone = (GameObject)Instantiate(cell, new Vector3(1, 1, 1), Quaternion.identity);
                cellClone.transform.SetParent(grid.transform);
                cellClone.transform.localScale = new Vector3(1, 1, 1);
                cellClone.name = "Cell[" + i + "][" + j + "]";
                cellArray[i] = j;
                Debug.LogError(i, j);
            }
        }
        foreach(KeyValuePair<int, int> entry in cellArray)
        {
            Debug.LogError(entry);   
        }
    }
}
