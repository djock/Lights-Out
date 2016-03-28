using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[Header("Game Elements")]
	public AutoGridLayout grid;
	public GameObject cell;
	public UIGame uiGame;

	[Header("Game Stats")]
	public int movesMade = 0;
	public int timeElapsed = 0;

	public static GameManager Instance;

	public GameObject[,] cellArray;
	public List<GameObject> cellList;

    GameObject cellClone;
	CellHandler cellHandler;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
		uiGame.endingText.gameObject.SetActive (false);
		StartCoroutine (GenerateGrid(2));
		CountElapsedTime ();
    }

	IEnumerator GenerateGrid(int columnCount)
    {
		grid.m_Column = columnCount;
		cellArray = new GameObject[columnCount*columnCount, columnCount*columnCount];
		yield return new WaitForEndOfFrame ();

        for (var i = 0; i < columnCount; i++)
        {
            for(var j = 0; j < columnCount; j++)
            {
				cellArray[i,j] = (GameObject)Instantiate(cell, new Vector3(1, 1, 1), Quaternion.identity);
				cellArray[i,j].transform.SetParent(grid.transform);
				cellArray[i,j].transform.localScale = new Vector3(1, 1, 1);
				cellArray[i,j].name = "Cell[" + i + "][" + j + "]";

				cellList.Add (cellArray[i,j]);

				cellHandler = cellArray[i,j].GetComponent<CellHandler> ();
				cellHandler.CoordX = i;
				cellHandler.CoordY = j;

				// Add color:
				var rand = Random.Range (0,2);

				if (rand == 1) {
					cellHandler.cellStatus = CellHandler.Status.On; 
					cellArray[i,j].GetComponent<CanvasRenderer> ().SetColor (new Color32 (135, 204, 196, 255));
				} else {
					cellHandler.cellStatus = CellHandler.Status.Off;
					cellArray[i,j].GetComponent<CanvasRenderer>().SetColor (new Color32 (128, 128, 128, 128));
				}
            }
        }
    }

	public void CountElapsedTime()
	{
		InvokeRepeating("elapsedTime", 1f, 1f);
	}
	void elapsedTime()
	{
		timeElapsed += 1;

	}

	public void CheckIfGameIsFinished() {

		var offCell = 0;

		foreach (var item in cellList) {
			if (item.GetComponent<CellHandler> ().cellStatus == CellHandler.Status.Off) {
				offCell++;
				Debug.LogError (item.gameObject.name + " " + offCell);
			}
		}
		if (offCell == grid.m_Column * grid.m_Column) {
			uiGame.endingText.transform.gameObject.SetActive (true);
		}
	}

}
