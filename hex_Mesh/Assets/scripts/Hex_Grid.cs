using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex_Grid : MonoBehaviour {

    public Transform hexPrefab;

    public int gridWidth = 11;
    public int gridHeigth = 11;

    float hexWidth = 1.732f;
    float hexHeigth = 2.0f;
    public float gap = 0.0f;

    Vector3 startPos;

    void Start()
    {
        addGap();
        calcStartPos();
        createGrid();
    }

    void addGap()
    {
        hexWidth += hexWidth * gap;
        hexHeigth += hexHeigth * gap;
    }

    void calcStartPos()
    {
        float offset = 0;
        if(gridHeigth / 2 % 2 != 0)
        {
            offset = hexWidth / 2;
        }

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeigth * 0.75f * (gridHeigth / 2);

        startPos = new Vector3(x, 0, z);

    }

    Vector3 calcWorldPos(Vector3 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
        {
            offset = hexWidth / 2;
        }

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeigth * 0.75f;

        return new Vector3(x, 0, z);
    }

    void createGrid()
    {
        for(int i = 0; i < gridHeigth; i++)
        {
            for (int k = 0; k < gridWidth; k++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(k, i);
                hex.position = calcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + k + "|" + i;
              
            }
        }
    }
}
