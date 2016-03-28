using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CellHandler : MonoBehaviour {


	public GameObject cell;

	public enum Status {
		On,
		Off
	}
	public Status cellStatus;

	public int CoordX {	get; set; }

	public int CoordY {	get; set; }

	public List<GameObject> adjacentCells;

	public void OnClick() {
		SwitchCellColor ();
		SwitchAdjacentCellColor ();
		GameManager.Instance.movesMade++;
		GameManager.Instance.CheckIfGameIsFinished ();
	}

	public void SwitchCellColor () {
		if (cellStatus == CellHandler.Status.On) {
			cellStatus = CellHandler.Status.Off;
			this.gameObject.GetComponent<CanvasRenderer>().SetColor(new Color32 (128, 128, 128, 128));
		} else {
			cellStatus = CellHandler.Status.On;
			this.gameObject.GetComponent<CanvasRenderer>().SetColor(new Color32 (135, 204, 196, 255));
		}
	}

	public void SwitchAdjacentCellColor() {
		StartCoroutine("ISwitchAdjacentCellColor");

	}

	IEnumerator ISwitchAdjacentCellColor() {
		
		GetAdjacentCells ();

		yield return new WaitForEndOfFrame ();
		foreach (var item in adjacentCells) {
			var selectedCell = item.GetComponent<CellHandler> ();

			if (selectedCell.cellStatus == Status.On) {
				selectedCell.cellStatus = Status.Off;
				item.gameObject.GetComponent<CanvasRenderer> ().SetColor (new Color32 (128, 128, 128, 128));
			} else {
				selectedCell.cellStatus = CellHandler.Status.On;
				item.gameObject.GetComponent<CanvasRenderer> ().SetColor (new Color32 (135, 204, 196, 255));
			}
		}
	}

	void GetAdjacentCells(){
		adjacentCells = new List<GameObject> ();

		GameObject northCell = null;
		GameObject westCell = null;
		GameObject eastCell = null;
		GameObject southCell = null;
		if (CoordX - 1 >= 0) {
			northCell = GameManager.Instance.cellArray [CoordX - 1, CoordY];
			adjacentCells.Add(northCell);
		}

		if (CoordY - 1 >= 0) {
			westCell = GameManager.Instance.cellArray [CoordX, CoordY - 1];
			adjacentCells.Add(westCell);
		
		}

		if (CoordY + 1 <= GameManager.Instance.grid.m_Column-1) {
			eastCell = GameManager.Instance.cellArray [CoordX, CoordY + 1];
			adjacentCells.Add(eastCell);
		}
		if (CoordX + 1 <= GameManager.Instance.grid.m_Column-1) {
			southCell = GameManager.Instance.cellArray [CoordX + 1, CoordY];
			adjacentCells.Add(southCell);
		
		}
	}
}