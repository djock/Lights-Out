using UnityEngine;
using UnityEngine.UI;

public class ColliderHandler : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cell")
        {
            if (other.gameObject.GetComponent<Image>().color == GameManager.Instance.cellOffColor)
            {
                other.gameObject.GetComponent<Image>().color = GameManager.Instance.cellOnColor;
            }
            else
            {
                other.gameObject.GetComponent<Image>().color = GameManager.Instance.cellOffColor;
            }
        }
    }
}
