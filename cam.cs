using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour {

	public Material line;
	public Grid g;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void drawli (Vector3 v1,Vector3 v2) {
		GL.Begin (GL.LINES);
		line.SetPass (0);
		GL.Color (Color.yellow);
		GL.Vertex (v1);
		GL.Vertex (v2);
		GL.End ();
		
	}


	void OnPostRender()
	{
		

		Vector3 worldPointup;
		Vector3 worldPointbottom;
		Vector3 worldBottomLeft = g.transform.position - Vector3.right * g.gridWorldSize.x / 2 - Vector3.forward * g.gridWorldSize.y / 2;	
		Vector3 worldTopleft = worldBottomLeft+Vector3.forward * g.gridWorldSize.y ;		

		for (int x = 0; x < g.gridSizeX; x = x + 1) {

			worldPointup = worldBottomLeft + Vector3.right * (x * g.nodeDiameter + g.nodeRadius);
			worldPointbottom = worldTopleft + Vector3.right * (x * g.nodeDiameter + g.nodeRadius);
			if (x % 10 < 5) {
				GL.Begin (GL.LINES);
				line.SetPass (0);

				GL.Color (Color.yellow);
				GL.Vertex3 (worldPointup.x,worldPointup.y,worldPointup.z );
				GL.Vertex3 (worldPointbottom.x,worldPointbottom.y,worldPointbottom.z);
				GL.End();
			}
		}
		Vector3 worldBottomRight=worldBottomLeft+Vector3.right * g.gridWorldSize.x ;	

		for (int y = 0; y < g.gridSizeY; y = y + 1) {

			worldPointup = worldBottomLeft + Vector3.forward * (y * g.nodeDiameter + g.nodeRadius);
			worldPointbottom = worldBottomRight + Vector3.forward * (y * g.nodeDiameter + g.nodeRadius);
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
}
