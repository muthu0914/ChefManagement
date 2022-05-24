using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameTester : MonoBehaviour
{
    public GridValues[] grid;
    //private Grid grid;
    private void Start()
    {
        foreach(GridValues g in grid)
        {
            GameObject newGrid = Instantiate(new GameObject());
            newGrid.AddComponent<Grid>();
            newGrid.GetComponent<Grid>().InitiateGrid(g);
        }
        
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    grid.SetValue(UtilsClass.GetMouseWorldPosition(), 77);
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    Debug.Log(grid.GetValue(UtilsClass.GetMouseWorldPosition()));
        //}
    }

    

}

[System.Serializable]
public class GridValues
{
    public int height;
    public int width;
    public float cellSize;
    public float offsetValue;
    public Vector3 originPosition;
}