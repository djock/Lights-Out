using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public ColliderHandler colliderHandler;
    public CellHandler cellHandler;

    public GameObject grid;
    public GameObject cell;

    public Color cellOffColor = new Color(0.53f, 0.8f, 0.77f);
    public Color cellOnColor = Color.yellow;

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    void OnEnable()
    {
        cell.gameObject.GetComponent<Image>().color = cellOffColor;

        var gridSize = 25;

        for(var i=1; i<= gridSize; i++) {
            GameObject cellClone = (GameObject)Instantiate(cell, new Vector3(1,1, 1), Quaternion.identity);
            cellClone.transform.SetParent(grid.transform);
            cellClone.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
