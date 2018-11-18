using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	

	Animator anim;
	public Transform target;
	public float speed = 20;
	public Vector3[] path;
	public Vector3[] path1;
	int targetIndex;
	public bool move;
	cam cm;

	void Start() {
		cm = GetComponent<cam> ();
			anim = GetComponent<Animator > ();
		PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {


		if (pathSuccessful) {
			path = newPath;
			targetIndex = 0;


				StopCoroutine ("FollowPath");
				StartCoroutine ("FollowPath");
			

		}
	}
	IEnumerator FollowPath() {
		


		Vector3 currentWaypoint = path[0];

		while (true ) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					anim.SetBool ("dest", true);
					yield break;
				}

				currentWaypoint = path[targetIndex];

			}

			if (move) {
				anim.SetBool ("dest", false);
	      /*  	 RaycastHit hit;
				Ray ray = new Ray (transform.position, currentWaypoint);
				if(Physics.Raycast(ray,out hit))
					{
						if(hit.collider.isTrigger)
						{

							PathRequestManager.RequestPath (transform.position, target.position, OnPathFound);
						}
					} 
					*/
				transform.position = Vector3.MoveTowards (transform.position, currentWaypoint, speed * Time.deltaTime);

				transform.rotation = Quaternion.LookRotation (currentWaypoint - transform.position);
			}
		

			yield return null;

		}
	}


	public void OnDrawGizmos() {

		if (path != null) {

			for (int i = targetIndex; i < path.Length; i ++) {
				Gizmos.color = Color.black;
				Gizmos.DrawCube(path[i], Vector3.one);
				for(int j=1;j<5;j++)
				if (i == targetIndex) {
						Gizmos.DrawLine(transform.position, path[i]);

				}
				else {
						Gizmos.DrawLine(path[i-1],path[i]);

				}
			
			}
		
		}
	}
}
