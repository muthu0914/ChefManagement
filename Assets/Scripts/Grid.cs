﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid<TGridObject>
{   
    private int height;
    private int width;
    private float cellSize;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Vector3 gridOffset;
    private Vector3 originPosition;

    public Grid(int height, int width,float cellSize,float offsetValue,Vector3 originPosition)
    {
        this.height = height;
        this.width = width;
        this.cellSize = cellSize;
        this.gridOffset = new Vector3(cellSize, cellSize) * offsetValue;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        debugTextArray = new TextMesh[width, height];

        GameObject grid = new GameObject();
        for(int x=0;x< gridArray.GetLength(0); x++)
        {
            for(int y = 0; y < gridArray.GetLength(1); y++)
            {
                debugTextArray[x,y]=CommonUtils.CreateWorldText(gridArray[x, y].ToString(), grid.transform, GetWorldPosition(x, y) + this.gridOffset, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y),Color.white,100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    }

    //public void InitiateGrid(GridValues gridValues)
    //{
    //    Grid grid = new Grid(gridValues.height, gridValues.width, gridValues.cellSize, gridValues.offsetValue, gridValues.originPosition);
    //}

    private Vector3 GetWorldPosition(int x, int y)
    {
        //Debug.LogWarning(x + " " + y + " " + cellSize + " " + originPosition + " "+(new Vector3(x, y) * cellSize + originPosition));
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellSize);
        //Debug.LogWarning(x + " " + y + " " + cellSize + " " + originPosition + " "+worldPosition);
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if(x>=0 && y>=0 && x<width&& y < height)
        {
            gridArray[x, y] = value;
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public TGridObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        else
        {
            return default(TGridObject);
        }
    }

    public TGridObject GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
