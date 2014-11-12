using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	private int turn;	//1 - białe 0 - czarne (wilk)
	private int pobieramCel; //1 - gdy pole z którego ruszamy jest już wybrane.
	private Transform checkedPion;
	private GameObject []fields;
	private GameObject lamb;
	private GameObject []wolfs;

	private int x, y, newX, newY;
	
	void Start () {
		turn = 1;
		pobieramCel = 0;
		fields = GameObject.FindGameObjectWithTag("Controller").GetComponent<Board>().board;
		lamb = GameObject.FindGameObjectWithTag("Controller").GetComponent<Board>().lamb;
		wolfs = GameObject.FindGameObjectWithTag ("Controller").GetComponent<Board> ().wolfs;
	}

	public void lambEvent(int x, int y, Transform pion){
		print ("LambEvent");
		if (turn == 1) {
			this.GetComponent<Checker>().isLambSurrounded(x,y);
			this.GetComponent<Checker>().isLambFree(x,y);
			pionEvent(x,y,pion);
		}
	}

	public void wolfEvent(int x, int y, Transform pion){
		if (turn == 0) {
			pionEvent(x,y,pion);
		}
	}

	private bool isCorrect(){
		bool flagFree = false;
		bool flagCorrectMove = false;
		flagFree = this.GetComponent<Checker> ().isFieldFree (newX, newY);
		if (turn == 1) {
			flagCorrectMove = this.GetComponent<Checker>().isLambCorrectMove(x,y,newX,newY);
		}else{
			flagCorrectMove = this.GetComponent<Checker>().isWolfCorrectMove(x,y,newX,newY);
		}
		if (flagFree && flagCorrectMove)
						return true;
		else {
			return false;
			}
	}

	public void fieldEvent(int x, int y){
		if (pobieramCel == 1) {	//Sprawdzam, czy miałem wybtać pole docelowe
			newX = x;
			newY = y;
			if(isCorrect ()){
				move ();
				pobieramCel = 0;
			}
		}
	}

	private void move(){
		checkedPion.Translate (new Vector3 (2*(newX - x),-2*(newY - y),0));
		if (turn == 1)
			turn = 0;
		else
			turn = 1;
		//blokada kolejki, usunięcie pól i zwolnienie pobieranaia docelowego pola
	}

	private void pionEvent(int x, int y, Transform pion){

			this.x = x;
			this.y = y;
			checkedPion = pion;
			pobieramCel = 1;

	}
}
