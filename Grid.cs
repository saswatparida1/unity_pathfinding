using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grid : MonoBehaviour {

	public LayerMask unwalkableMask;
	public Vector2 gridWorldSize;
	public float nodeRadius;
	public Material line;
	Node[,] grid;
	public float nodeDiameter;
	public int gridSizeX, gridSizeY;

	void Awake() {
		nodeDiameter = nodeRadius;
		gridSizeX = Mathf.RoundToInt(gridWorldSize.x/nodeDiameter);
		gridSizeY = Mathf.RoundToInt(gridWorldSize.y/nodeDiameter);
		CreateGrid();
	}

	public int MaxSize {
		get {
			return gridSizeX * gridSizeY;
		}
	}

	void CreateGrid() {
		grid = new Node[gridSizeX,gridSizeY];
		bool walkable = false;
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x/2 - Vector3.forward * gridWorldSize.y/2;

		for (int x = 0; x < gridSizeX; x =x+1) {
			for (int y = 0; y < gridSizeY; y=y+1) {
				Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius) + Vector3.forward * (y * nodeDiameter + nodeRadius);
				walkable = false;
				if (y % 10 <5) {
					walkable = !(Physics.CheckSphere (worldPoint, nodeRadius, unwalkableMask));
				} else {
					if (x % 10 <5) {

						walkable = !(Physics.CheckSphere (worldPoint, nodeRadius, unwalkableMask));
					}
				}
				grid[x,y] = new Node(walkable,worldPoint, x,y);
			}
		}
	}

	public List<Node> GetNeighbours(Node node) {
		List<Node> neighbours = new List<Node>();

		for (int x = -1; x <= 1; x++) {
			for (int y = -1; y <= 1; y++) {
				if (x == 0 && y == 0)
					continue;

				int checkX = node.gridX + x;
				int checkY = node.gridY + y;
				if (checkX >= 0 && checkX < gridSizeX && checkY >= 0 && checkY < gridSizeY) {
					if (grid [checkX, checkY].walkable)
					neighbours.Add(grid[checkX,checkY]);
				}
			}
		}

		return neighbours;
	}
	

	public Node NodeFromWorldPoint(Vector3 worldPosition) {
		float percentX = (worldPosition.x + gridWorldSize.x/2) / gridWorldSize.x;
		float percentY = (worldPosition.z + gridWorldSize.y/2) / gridWorldSize.y;
		percentX = Mathf.Clamp01(percentX);
		percentY = Mathf.Clamp01(percentY);

		int x = Mathf.RoundToInt((gridSizeX-1) * percentX);
		int y = Mathf.RoundToInt((gridSizeY-1) * percentY);
		return grid[x,y];
	}

  void OnDrawGizmos()
	{
		
		Vector3 worldPointup;
		Vector3 worldPointbottom;
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;	
		Vector3 worldTopleft = worldBottomLeft+Vector3.forward * gridWorldSize.y ;	

		for (int x = 0; x < gridSizeX; x = x + 1) {
			
			worldPointup = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius);
			worldPointbottom = worldTopleft + Vector3.right * (x * nodeDiameter + nodeRadius);
			Gizmos.color = Color.clear;
			if (x % 10 < 5) {
				Gizmos.color =Color.black;
				Gizmos.DrawLine (worldPointup,worldPointbottom);	
			}
		}
		Vector3 worldBottomRight=worldBottomLeft+Vector3.right * gridWorldSize.x ;	

		for (int y = 0; y < gridSizeY; y = y + 1) {

			worldPointup = worldBottomLeft + Vector3.forward * (y * nodeDiameter + nodeRadius);
			worldPointbottom = worldBottomRight + Vector3.forward * (y * nodeDiameter + nodeRadius);
			Gizmos.color = Color.clear;
			if (y % 10 < 5) {

				Gizmos.color =Color.black;
				Gizmos.DrawLine (worldPointup,worldPointbottom);	
			}
		}
	
	}
	/*
	void OnPost()
	{
		
		Vector3 worldPointup;
		Vector3 worldPointbottom;
		Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;	
		Vector3 worldTopleft = worldBottomLeft+Vector3.forward * gridWorldSize.y ;		

		for (int x = 0; x < gridSizeX; x = x + 1) {

			worldPointup = worldBottomLeft + Vector3.right * (x * nodeDiameter + nodeRadius);
			worldPointbottom = worldTopleft + Vector3.right * (x * nodeDiameter + nodeRadius);
			if (x % 10 < 5) {
				GL.Begin (GL.LINES);
				line.SetPass (0);

				GL.Color (Color.magenta);
				GL.Vertex3 (worldPointup.x,worldPointup.y,worldPointup.z );
				GL.Vertex3 (worldPointbottom.x,worldPointbottom.y,worldPointbottom.z);
				GL.End();
			}
		}
		Vector3 worldBottomRight=worldBottomLeft+Vector3.right * gridWorldSize.x ;	

		for (int y = 0; y < gridSizeY; y = y + 1) {

			worldPointup = worldBottomLeft + Vector3.forward * (y * nodeDiameter + nodeRadius);
			worldPointbottom = worldBottomRight + Vector3.forward * (y * nodeDiameter + nodeRadius);
			if (y % 10 < 5) {
				GL.Begin (GL.LINES);
				line.SetPass (0);

				GL.Color (Color.magenta);
				GL.Vertex3 (worldPointup.x,worldPointup.y,worldPointup.z );
				GL.Vertex3 (worldPointbottom.x,worldPointbottom.y,worldPointbottom.z);
				GL.End();
			}
		}
	}
	*/


}