using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPF
{
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private PathNode[,] gridArray;

    public GridPF(int width, int height, float cellSize, Vector3 originPosition)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new PathNode[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                gridArray[x, y] = new PathNode(this, x, y);
    }

    public PathNode GetGridObject(int x, int y)
    {
        return gridArray[x, y];
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }
}
