using UnityEngine;
using System.Collections;

public class Wolf : MonoBehaviour {
	private Controller controller;
	
	void Start () {
		GameObject obj;
		obj = GameObject.FindGameObjectWithTag ("Controller");
		controller = obj.GetComponent<Controller>();
	}
	
	void Update () {
		
	}
	
	void OnMouseDown(){
		Transform me = this.GetComponent<Transform>().transform;
		print ("Wolf event");
		controller.wolfEvent((int)((this.transform.position.x - 1) / 2),(int)((this.transform.position.z - 1) / 2),me);
	}
}
