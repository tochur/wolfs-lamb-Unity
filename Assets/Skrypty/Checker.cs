using UnityEngine;
using System.Collections;
using System;

public class Checker : MonoBehaviour {
	private GameObject []fields;
	private GameObject lamb;
	private GameObject []wolfs;
	// Use this for initialization
	void Start () {
		fields = GameObject.FindGameObjectWithTag("Controller").GetComponent<Board>().board;
		lamb = GameObject.FindGameObjectWithTag("Controller").GetComponent<Board>().lamb;
		wolfs = GameObject.FindGameObjectWithTag ("Controller").GetComponent<Board> ().wolfs;
	}

	public bool isLambSurrounded(int x, int y){
		print("checking lamb surround");
		bool flag = true;
		int []surroundX = {x - 1, x - 1, x + 1, x + 1};
		int []surroundY = {y - 1, y + 1, y + 1, y - 1};
		for(int i = 0; i<4 ; i++){
			if( fieldBelongsToBoard(surroundY[i],surroundX[i])  && isFieldFree(surroundX[i],surroundY[i]) ){
				print ("Wolne pote to x = "+surroundX[i]+ " y = "+surroundY[i]);
				flag = false;
				break;
			}
			print("Checked option "+i);
		}
		if (flag == true) {
			print ("WOLFS WON, CONGRATULATION !!!");
		}
		return flag;
	}

	public bool isLambFree(int x, int y){
		int wolfsRemaining = 0;
		for(int i = 0;i<4;i++){
			print ("CHECKING wolfs"+i);
			print("KOORDYNATY WILKA "+i);
			print("x = "+(int)((wolfs[i].transform.position.x -1)/2));
			print("y = "+(int)((wolfs[i].transform.position.z -1)/2));
			print("lamb pos "+x+" "+y);
			if(((int)((wolfs[i].transform.position.z -1)/2)) > y){
				wolfsRemaining++;
			}
		}
		if (wolfsRemaining >= 2) {
			print("STILL NOT FREE remain: "+wolfsRemaining);
						return false;
				} else {
						print ("LAMB WON CONGRATULATION");
						return true;
				}
	}

	private bool fieldBelongsToBoard(int x, int y){
		if (x < 8 && x >= 0 && y < 8 && y >= 0)
						return true;
				else {
						return false;
				}
	}

	public bool isLambCorrectMove(int x, int y, int newX, int newY){
		print ("x: " + x + "y: " + y + "newX: " + newX + "newY: " + newY);
		if (Math.Abs (x - newX) == 1 && Math.Abs (y - newY) == 1) {
						print ("Correct lamb move");
						return true;
				} else
						print ("IN Correct lamb move");
		return false;
	}

	public bool isWolfCorrectMove(int x, int y, int newX, int newY){
		print ("x: " + x + "y: " + y + "newX: " + newX + "newY: " + newY);
		if( newY - y == -1 && (newX-x == 1 || x - newX == 1) ){
			print ("Correct wolf move");
			return true;
		} else
			print ("IN Correct wolf move");
		return false;
	}

	public bool isFieldFree(int newX, int newY){
		print ("Is field free");
		bool flag = true;
		for(int i = 0;i<4;i++){
				print ("CHECKING wolfs"+i);
				print("KOORDYNATY WILKA "+i);
			print("x = "+(int)((wolfs[i].transform.position.x -1)/2));
			print("y = "+(int)((wolfs[i].transform.position.z -1)/2));
				print("cel "+newX+" "+newY);
				if(((int)((wolfs[i].transform.position.x -1)/2)) == newX &&  ((int)((wolfs[i].transform.position.z -1)/2) == newY)){
					print ("Pole "+newX+" "+newY+" zajęte przez wilka "+i);
					flag = false;
					break;
				}	
		}
		print ("CHECKING lamb");
		if(((int)(lamb.transform.position.x -1)/2) == newX &&  ((int)(lamb.transform.position.z -1)/2) == newY){
			print ("Pole "+newX+" "+newY+" zajęte przez owce.");
			flag = false;
		}
		if (flag == true)
						print ("FREE FIELD");
		return flag;
	}

}
