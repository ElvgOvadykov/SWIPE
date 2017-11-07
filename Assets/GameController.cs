using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

	public Vector3 fp;   //Первая позиция касания
	public Vector3 lp;   //Последняя позиция касания
	public float dragDistance;  //Минимальная дистанция для определения свайпа
	public List<Vector3> touchPositions = new List<Vector3>(); //Храним все позиции касания в списке
	public GameObject arr;
	public float force = 700f;
	public Text main,record;
	public Image img;

	// Use this for initialization
	void Start () {
		dragDistance = Screen.height*15/100;
		record.text += " " + PlayerPrefs.GetInt ("max_score").ToString ();//dragDistance это 20% высоты экра
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches)  //используем цикл для отслеживания больше одного свайпа
		{ //должны быть закоментированы, если вы используете списки 


			if (touch.phase == TouchPhase.Moved) //добавляем касания в список, как только они определены
			{
				touchPositions.Add(touch.position);
			}

			if (touch.phase == TouchPhase.Ended) //проверяем, если палец убирается с экрана
			{
				//lp = touch.position;  //последняя позиция касания. закоментируйте если используете списки
				if (touchPositions.Count != 0) {
					fp = touchPositions [0]; //получаем первую позицию касания из списка касаний

					lp = touchPositions [touchPositions.Count - 1];
				} //позиция последнего касания
				touchPositions.Clear();
				//проверяем дистанцию перемещения больше чем 20% высоты экрана
				if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
				{//это перемещение
					//проверяем, перемещение было вертикальным или горизонтальным 
					if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
					{   //Если горизонтальное движение больше, чем вертикальное движение ...
						if ((lp.x>fp.x))  //Если движение было вправо
						{   

						}
						else
						{   //Свайп влево
					
						}
					}
					else
					{   //Если вертикальное движение больше, чнм горизонтальное движение
						if (lp.y>fp.y)  //Если движение вверх
						{   //Свайп вверх
							arr.GetComponent<Animation>().enabled = false;
							arr.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
							arr.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * force);
							main.GetComponent<Animation> ().Play ();
							record.GetComponent<Animation> ().Play ();
							img.GetComponent<Animation> ().Play ();
							StartCoroutine ("scene");
						}
						else 
						{  
							Debug.Log("Down Swipe");
						} 
					}
				} 
			}
			else
			{   
		
			}
		}

	}
	public IEnumerator scene(){
		yield return new WaitForSeconds (1.3f);
		SceneManager.LoadScene (1);
	}



}
