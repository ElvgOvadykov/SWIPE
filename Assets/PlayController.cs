using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayController : MonoBehaviour {

	public Vector3 fp;   //Первая позиция касания
	public Vector3 lp;   //Последняя позиция касания
	public float dragDistance;  //Минимальная дистанция для определения свайпа
	public List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке
	public GameObject arrow;
	public GameObject square;
	private int score;
	// Use this for initialization
	void Start () {
		dragDistance = Screen.height*15/100;
	}

	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches)
		{


			if (touch.phase == TouchPhase.Moved) 
			{
				touchPositions.Add(touch.position);
			}

			if (touch.phase == TouchPhase.Ended) 
			{
		
				if (touchPositions.Count != 0) {
					fp = touchPositions [0];

					lp = touchPositions [touchPositions.Count - 1];
				}
				touchPositions.Clear();

				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{
					arrow = GameObject.FindGameObjectWithTag ("arrow");
					//проверяем, перемещение было вертикальным или горизонтальным 
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
						
					{   //Если горизонтальное движение больше, чем вертикальное движение ...
						
						if ((lp.x>fp.x))  //Если движение было вправо
						{   
							if (square.GetComponent<Collision> ().isCol && this.GetComponent<Arrows>().rand1 == 0) {
								square.GetComponent<Collision> ().isCol = false;
								this.GetComponent<Arrows> ().NewLevel ();
							} else {
								score = this.GetComponent<Arrows> ().counter;
								if (score > PlayerPrefs.GetInt("max_score")){
									PlayerPrefs.SetInt ("max_score", score);
								}
								PlayerPrefs.SetInt ("score", score);
								SceneManager.LoadScene (2);
							}
						}
						else
						{   //Свайп влево
							if (square.GetComponent<Collision> ().isCol && this.GetComponent<Arrows>().rand1 == 2) {
								square.GetComponent<Collision> ().isCol = false;
								this.GetComponent<Arrows> ().NewLevel ();
							} else {
								score = this.GetComponent<Arrows> ().counter;
								if (score > PlayerPrefs.GetInt("max_score")){
									PlayerPrefs.SetInt ("max_score", score);
								}
								PlayerPrefs.SetInt ("score", score);
								SceneManager.LoadScene (2);
							}
						}
					}
					else
					{   //Если вертикальное движение больше, чнм горизонтальное движение
						if (lp.y>fp.y)  //Если движение вверх
						{   //Свайп вверх
							if (square.GetComponent<Collision> ().isCol && this.GetComponent<Arrows>().rand1 == 1) {
								square.GetComponent<Collision> ().isCol = false;
								this.GetComponent<Arrows> ().NewLevel ();
							} else {
								score = this.GetComponent<Arrows> ().counter;
								if (score > PlayerPrefs.GetInt("max_score")){
									PlayerPrefs.SetInt ("max_score", score);
								}
								PlayerPrefs.SetInt ("score", score);
								SceneManager.LoadScene (2);
							}
						}
						else 
						{  
							if (square.GetComponent<Collision> ().isCol && this.GetComponent<Arrows>().rand1 == 3) {
								square.GetComponent<Collision> ().isCol = false;
								this.GetComponent<Arrows> ().NewLevel ();
							} else {
								score = this.GetComponent<Arrows> ().counter;
								if (score > PlayerPrefs.GetInt("max_score")){
									PlayerPrefs.SetInt ("max_score", score);
								}
								PlayerPrefs.SetInt ("score", score);
								SceneManager.LoadScene (2);
							}
						} 
					}
				} 
			}
			else
			{   

			}
		}

	}

	public IEnumerator dstr(){
		yield return new WaitForSeconds (0.5f);

	}


}
