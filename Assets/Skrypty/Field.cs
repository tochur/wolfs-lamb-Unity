using UnityEngine;
using System.Collections;

public class Field : MonoBehaviour {
	public int x,y;
	private Controller controller;
	// Use this for initialization
	void Start () {
		GameObject obj;
		obj = GameObject.FindGameObjectWithTag ("Controller");
		controller = obj.GetComponent<Controller>();
		x = (int)((this.transform.position.x - 1) / 2);
		y = (int)((this.transform.position.z - 1) / 2);
	}

	void OnMouseDown(){
		print ("To pole moje koordynaty to: " + x + " " + y);
		controller.fieldEvent (x, y);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
