using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIGame : MonoBehaviour {

	public Text movesMadeLabel;
	public Text timeElapsedLabel;
	public Text endingText;

	void Update() {
		movesMadeLabel.text = "Moves made: " + GameManager.Instance.movesMade.ToString ();

		if (GameManager.Instance.timeElapsed < 60) {
			timeElapsedLabel.text = "Time elapsed: " + GameManager.Instance.timeElapsed.ToString ();
		} else {
			int seconds = GameManager.Instance.timeElapsed % 60;
			int minutes = GameManager.Instance.timeElapsed / 60;

			timeElapsedLabel.text = "Time elapsed: " + minutes + "m " + seconds + "s";
			endingText.text = "Congratulations";
		}
	}
}
