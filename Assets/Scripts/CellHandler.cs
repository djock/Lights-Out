using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellHandler : MonoBehaviour {

    public void OnClick()
    {
        var child = transform.FindChild("Collider");
        child.gameObject.SetActive(true);
        SwitchCellColor();
        StartCoroutine("DeactivateCellCollider");
    }

    public void OnMouseOver()
    {
        Debug.LogError(gameObject.name);
    }

    public void SwitchCellColor()
    {
        if (gameObject.GetComponent<Image>().color == GameManager.Instance.cellOffColor)
        {
            gameObject.GetComponent<Image>().color = GameManager.Instance.cellOnColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = GameManager.Instance.cellOffColor;
        }
    }

    IEnumerator DeactivateCellCollider()
    {
        yield return new WaitForSeconds(0.1f);
        var child = transform.FindChild("Collider");
        child.gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
