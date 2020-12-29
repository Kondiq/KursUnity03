using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    private GridPF grid;
    private int x;
    private int y;

    public int gCost;
    public int hCost; //distance while ignoring all of the blockable areas
    public int fCost; //gCost+hCost

    public bool isWalkable;
    public PathNode cameFromNode;

    public PathNode(GridPF grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    public override string ToString()
    {
        return x + "," + y;
    }

    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
}
