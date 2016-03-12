using UnityEngine;
using System.Collections;

public class CellHandler : MonoBehaviour {


	public GameObject cell;

	public enum Status {
		On,
		Off
	}
	public Status cellStatus;


	public void OnClick() {
		if (cellStatus == Status.On) {
			cellStatus = Status.Off;
			gameObject.GetComponent<CanvasRenderer>().SetColor(new Color32 (128, 128, 128, 128));
		} else {
			cellStatus = Status.On;
			gameObject.GetComponent<CanvasRenderer>().SetColor(new Color32 (135, 204, 196, 255));
		}
	}
}
