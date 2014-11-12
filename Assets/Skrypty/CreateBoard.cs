using UnityEngine;
using System.Collections;

public class CreateBoard : MonoBehaviour {
	public GameObject lambPrefab;
	public GameObject wolfPrefab;
	private GameObject whiteField;
	private GameObject blackField;


	public GameObject lamb;
	public GameObject []wolfs = new GameObject[4];
	public GameObject []board = new GameObject[64];




	void Start () {
		whiteField = GameObject.FindWithTag("White");
		blackField = GameObject.FindWithTag ("Black");
		for (int i = 0; i<8; i++) {
			for( int j = 0; j<8; j++){
				if(i%2 == 0){	//jeśli rząd parzysty (zaczynam od czarnago - parzyste)
					if(j%2 != 0){	//nieparzyste - białe
						board[i*8 + j] = (GameObject)Instantiate(whiteField);
						board[i*8 + j].transform.Translate(new Vector3(2 * j-2, 0, 2 * i));
					}else{
						board[i*8 + j] = (GameObject)Instantiate(blackField);
						board[i*8 + j].transform.Translate(new Vector3(2 * j, 0, 2 * i));
					}
				}else{	//jeśli nieparzysty rząd zczynam od białych ( parzyste)
					if(j%2 == 0){
						board[i*8 + j] = (GameObject)Instantiate(whiteField);
						board[i*8 + j].transform.Translate(new Vector3(2 * j-2, 0, 2 * i));
					}else{
						board[i*8 + j] = (GameObject)Instantiate(blackField);
						board[i*8 + j].transform.Translate(new Vector3(2 * j, 0, 2 * i));
					}
				}
			}
		}

		/*Lepiej je usunąć*/
		Destroy (blackField);
		Destroy (whiteField);

		lamb = (GameObject)Instantiate(lambPrefab);
		lamb.transform.Translate (new Vector3 (5,-1,0.3f));

		for (int i = 0; i<4; i++) {
			wolfs[i] = (GameObject)Instantiate(wolfPrefab);
			wolfs[i].transform.Translate(new Vector3(3+4*i,-15,0.3f));
		}
	}

}
