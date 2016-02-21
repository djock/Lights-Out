using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    AutoGridLayout grid;

    [SerializeField]
    GameObject cell;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        var cellCount = grid.m_Column * grid.m_Column;

        for (var i = 1; i <= cellCount; i++)
        {
            GameObject cellClone = (GameObject)Instantiate(cell, new Vector3(1, 1, 1), Quaternion.identity);
            cellClone.transform.SetParent(grid.transform);
            cellClone.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
