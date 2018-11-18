using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class buttonmovement: MonoBehaviour
{
	public GameObject prefab5;
	public GameObject prefab10;
	public GameObject prefab15;
	public GameObject prefab20;
	public GameObject prefab25;
	public GameObject prefab2_5;
	public GameObject prefab2_10;
	public GameObject prefab2_15;
	public GameObject prefab2_20;
	public GameObject prefab2_25;
	public Transform  prefab1;
	GameObject obj_1;
	GameObject obj_2;
	GameObject obj_3;
	GameObject obj_4;
	GameObject obj_5;
	GameObject obj2_1;
	GameObject obj2_2;
	GameObject obj2_3;
	GameObject obj2_4;
	GameObject obj2_5;

	Transform obj1;
	Ray ray;
	RaycastHit hit;
	int s1_1=0;
	int s1_2=0;
	int s1_3=0;
	int s1_4=0;
	int s1_5=0;

	int s2_1=0;
	int s2_2=0;
	int s2_3=0;
	int s2_4=0;
	int s2_5=0;


	public Vector3[] path2 ;
	public Text tx;
	public GameObject ob;


	void Start()
	{
		
	}




	void Update ()
	{

		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {
			

			if (Input.GetKeyUp (KeyCode.Alpha1)) {
				obj_1 = Instantiate (prefab5, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj_1.name = "sas5" + s1_1;
				s1_1++;
		
					}

			if (Input.GetKeyUp (KeyCode.Alpha2 )) {
				obj_2 = Instantiate (prefab10, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj_2.name = "sas10" + s1_2;
				s1_2++;

			}
			if (Input.GetKeyUp (KeyCode.Alpha3 )) {
				obj_3 = Instantiate (prefab15, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj_3.name = "sas15" + s1_3;
				s1_3++;

			}
			if (Input.GetKeyUp (KeyCode.Alpha4 )) {
				obj_4 = Instantiate (prefab20, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj_4.name = "sas20" + s1_4;
				s1_4++;

			}
			if (Input.GetKeyUp (KeyCode.Alpha5 )) {
				obj_5 = Instantiate (prefab25, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj_5.name = "sas25" + s1_5;
				s1_5++;

			}
			if (Input.GetKeyUp (KeyCode.A)) {
				obj2_1= Instantiate (prefab2_5, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj2_1.name = "a*5" + s2_1;
				s2_1++;

			}

			if (Input.GetKeyUp (KeyCode.B)) {
				obj2_2= Instantiate (prefab2_10, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj2_2.name = "a*10" + s2_2;

				s2_2++;

			}
			if (Input.GetKeyUp (KeyCode.C)) {
				obj2_3= Instantiate (prefab2_15, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj2_3.name = "a*15" + s2_3;

				s2_3++;

			}
			if (Input.GetKeyUp (KeyCode.D)) {
				obj2_4= Instantiate (prefab2_20, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj2_4.name = "a*20" + s2_4;

				s2_4++;

			}
			if (Input.GetKeyUp (KeyCode.E)) {
				obj2_5= Instantiate (prefab2_25, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity) as GameObject;
				obj2_5.name = "a*25" + s2_5;

				s2_5++;

			}


				if (Input.GetKeyUp (KeyCode.Mouse0)) {
				obj1 = Instantiate (prefab1, new Vector3 (hit.point.x, hit.point.y, hit.point.z), Quaternion.identity);
				prefab5.GetComponent<Unit> ().target.position = obj1.position;
				prefab2_5.GetComponent<Unit> ().target.position = obj1.position;
				prefab10.GetComponent<Unit> ().target.position = obj1.position;
				prefab2_10.GetComponent<Unit> ().target.position = obj1.position;
				prefab15.GetComponent<Unit> ().target.position = obj1.position;
				prefab2_15.GetComponent<Unit> ().target.position = obj1.position;
				prefab20.GetComponent<Unit> ().target.position = obj1.position;
				prefab2_20.GetComponent<Unit> ().target.position = obj1.position;
				prefab25.GetComponent<Unit> ().target.position = obj1.position;
				prefab2_25.GetComponent<Unit> ().target.position = obj1.position;

				}

		}
		if (Input.GetKeyUp (KeyCode.S)) {
			for (int cnt = 0; cnt < s1_1; cnt++) {
				GameObject sas = GameObject.Find ("sas5" + cnt); 


				sas.GetComponent<Unit> ().move = true;



			}

			for (int cnt = 0; cnt < s1_2; cnt++) {
				GameObject sas = GameObject.Find ("sas10" + cnt); 


				sas.GetComponent<Unit> ().move = true;



			}
			for (int cnt = 0; cnt < s1_3; cnt++) {
				GameObject sas = GameObject.Find ("sas15" + cnt); 


				sas.GetComponent<Unit> ().move = true;



			}
			for (int cnt = 0; cnt < s1_4; cnt++) {
				GameObject sas = GameObject.Find ("sas20" + cnt); 


				sas.GetComponent<Unit> ().move = true;



			}
			for (int cnt = 0; cnt < s1_5; cnt++) {
				GameObject sas = GameObject.Find ("sas25" + cnt); 


				sas.GetComponent<Unit> ().move = true;



			}
			for (int cnt = 0; cnt < s2_1; cnt++) {
				GameObject sas1 = GameObject.Find ("a*5" + cnt); 

				sas1.GetComponent<Unit> ().move = true;
			}

			for (int cnt = 0; cnt < s2_2; cnt++) {
				GameObject sas1 = GameObject.Find ("a*10" + cnt); 

				sas1.GetComponent<Unit> ().move = true;
			}

			for (int cnt = 0; cnt < s2_3; cnt++) {
				GameObject sas1 = GameObject.Find ("a*15" + cnt); 

				sas1.GetComponent<Unit> ().move = true;
			}
			for (int cnt = 0; cnt < s2_4; cnt++) {
				GameObject sas1 = GameObject.Find ("a*20" + cnt); 

				sas1.GetComponent<Unit> ().move = true;
			}
			for (int cnt = 0; cnt < s2_5; cnt++) {
				GameObject sas1 = GameObject.Find ("a*25" + cnt); 

				sas1.GetComponent<Unit> ().move = true;
			}

		}

	}

}
