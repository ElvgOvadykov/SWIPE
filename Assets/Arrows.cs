using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arrows : MonoBehaviour {
	public Vector3[] positions;
	public Quaternion[] rotations;
	public int rand,rand1;
	public GameObject arrow;
	public Camera mc;
	public float a;
	public GameObject CurrArr;
	public float speed;
	public Text score;
	[HideInInspector]
	public int counter = 0;

	// Use this for initialization
	void Start () {
		positions = new Vector3[4];
		rotations = new Quaternion[4];
		rotations [0] = Quaternion.Euler (0, 0, 0);
		rotations [1] = Quaternion.Euler (0, 0, 90);
		rotations [2] = Quaternion.Euler (0, 0, 180);
		rotations [3] = Quaternion.Euler (0, 0, 270);
		speed = 30f;
		positions [0] = new Vector3 (0, 4.14f , 0);
		positions [1] = new Vector3 (0, -4.14f , 0);
		positions [2] = new Vector3 (2.85f,0, 0);
		positions [3] = new Vector3 (-2.85f,0, 0);
		rand = Random.Range (0, 4);
		rand1 = Random.Range (0, 4);
		Instantiate (arrow, positions [rand], rotations[rand1]);
		CurrArr = GameObject.FindGameObjectWithTag ("arrow");

		if (rand == 0) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.down*speed);
		}
		if (rand == 1) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.up*speed);
		}
		if (rand == 2) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.left*speed);
		}
		if (rand == 3) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.right*speed);
		}
	}
	
	// Update is called once per frame
	void Update () {
		score.text = counter.ToString ();
	}
	public void NewLevel(){
		Destroy (CurrArr);
		StartCoroutine ("InstNew");

	}
	public IEnumerator InstNew(){
		counter++;
		speed += 20f;
		yield return new WaitForEndOfFrame ();
		rand = Random.Range (0, 4);
		rand1 = Random.Range (0, 4);
		Instantiate (arrow, positions [rand], rotations[rand1]);
		CurrArr = GameObject.FindGameObjectWithTag ("arrow");
		if (rand == 0) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.down*speed);
		} 
		if (rand == 1) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.up*speed);
		} 
		if (rand == 2) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.left*speed);
		
		} 
		if (rand == 3) {
			CurrArr.GetComponent<Rigidbody> ().AddForce (Vector3.right*speed);

		}
	
	}
}
