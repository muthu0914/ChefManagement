using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class GameTester : MonoBehaviour
{
    [SerializeField] private PathfindingVisual pathfindingVisual;
    private Pathfinding pathfinding;
    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
        pathfindingVisual.SetGrid(pathfinding.GetGrid());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = CommonUtils.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mousePosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for(int i = 0; i < path.Count-1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, 
                        new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.red, 5f);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = CommonUtils.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mousePosition, out int x, out int y);
            PathNode node = pathfinding.GetNode(x, y);
            if (node != null)
            {
                node.SetIsWalkable(!node.isWalkable);
            }
        }
    }



}
