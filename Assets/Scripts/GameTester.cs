using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameTester : MonoBehaviour
{
    //public GridValues[] grid;
    private Grid<bool> grid;
    private void Start()
    {
        grid = new Grid<bool>(4, 2,5, 0.5f, new Vector3(-10, -5, 0));
        new Grid<int>(4, 3,5, 0.5f, new Vector3(-40, -5, 0));
        //foreach (GridValues g in grid)
        //{
        //    GameObject newGrid = Instantiate(new GameObject());
        //    newGrid.AddComponent<Grid>();
        //    newGrid.GetComponent<Grid>().InitiateGrid(g);
        //}

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

//[System.Serializable]
//public class GridValues
//{
//    public int height;
//    public int width;
//    public float cellSize;
//    public float offsetValue;
//    public Vector3 originPosition;
//}