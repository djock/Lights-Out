using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    [SerializeField]
    AutoGridLayout grid;
    [SerializeField]
    GameObject cell;

	public CellHandler cellHandler;
	public static GameManager Instance;

	Dictionary<int, int> cellArray = new Dictionary<int, int>();
    GameObject cellClone;

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

				SetCellColor ();
            }
        }

    }

	void SetCellColor() {
		var rand = Random.Range (0,2);

		if (rand <= 0.5) {
			cellHandler.cellStatus = CellHandler.Status.On;
			cellClone.GetComponent<CanvasRenderer> ().SetColor (new Color32 (135, 204, 196, 255));
		} else {
			cellHandler.cellStatus = CellHandler.Status.Off;
			cellClone.GetComponent<CanvasRenderer>().SetColor (new Color32 (128, 128, 128, 128));
		}
	}

}
