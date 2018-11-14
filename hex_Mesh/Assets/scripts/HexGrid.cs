using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour {

    public int width = 6;
    public int heigth = 6;

    public Text cellLabelPrefab;

    Canvas gridCanvas;

    public HexCell cellPrefab;
    HexCell[] cells;
    HexMesh hexMesh;

    void Awake()
    {      
        hexMesh = GetComponentInChildren<HexMesh>();
        gridCanvas = GetComponentInChildren<Canvas>();

        cells = new HexCell[heigth * width];

        for(int z = 0, k = 0; z < heigth; z++)
        {
            for(int x = 0; x < width; x++)
            {
                CreateCell(x, z, k++);
            }
        }
    }
    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    void CreateCell(int x, int z, int i)
    {
        Vector3 position;
        position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2.1f);
        position.y = 0f;
        position.z = z * (HexMetrics.outerRadius * 1.5f);

        Text label = Instantiate<Text>(cellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition =
            new Vector2(position.x, position.z);
        label.text = x.ToString() + "\n" + z.ToString();

        HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);    
          
    }
         
}
