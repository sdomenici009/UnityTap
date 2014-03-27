using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	int score;
	int printScore;
	GameObject ball;
	GameObject screenColliders;
	public GameObject wall1, wall2, wall3, wall4;
	public GameObject enemies;
	public GUIStyle style = new GUIStyle();
	Rect textArea = new Rect(Screen.width/2, Screen.height/2,0,0);
	GUIContent scoreText;
	string scoreString;
	int randomTime;
	List<Color> colors = new List<Color>();
	public bool dead = false;
	
	void OnGUI () {
    	GUI.Label (textArea, printScore.ToString(), style);
		
		if(dead)
		{
			if(GUI.Button(new Rect(Screen.width/2 - 150, Screen.height/2 + 90, 300, 60), "Reset"))
				Application.LoadLevel(0);
		}
    }
	
	void Start () {
		Random.seed = System.Environment.TickCount;
		wall1.renderer.material.color = Color.black;
		wall2.renderer.material.color = Color.black;
		wall3.renderer.material.color = Color.black;
		wall4.renderer.material.color = Color.black;
		ball = (GameObject)Instantiate(Resources.Load("Ball"));
		ball.GetComponent<Ball>().gm = this;
		score = 0;
		printScore = 0;
		style.fontSize = 15;
		style.alignment = TextAnchor.LowerCenter;
		randomTime = 50;
		colors.Add(Color.red);
		colors.Add(Color.blue);
		colors.Add(Color.green);
		colors.Add(Color.yellow);
	}
	
	// Update is called once per frame
	void Update () {
		if(!dead)
		{
			score += 1;
			
			if(score%10 == 0)
				printScore += 10;
	
			
			if(score%500 == 0)
			{
				style.fontSize += 20;
				textArea.y += 12;
				
				if(randomTime > 5)
					randomTime -= 5;
			}
		}
		
		if(Random.Range(0, randomTime) == 0)
		{
			GameObject enemy = (GameObject)Instantiate(Resources.Load ("Enemy"));
			enemy.transform.parent = enemies.transform;
			enemy.renderer.material.color = colors[Random.Range(0, 4)];
			Destroy(enemy, 6);
			
			if(Random.Range(0, 2) == 1)
			{
				enemy.transform.position = new Vector3(-10, Random.Range(-7, 7), 0);
			}
			else
			{
				enemy.transform.position = new Vector3(10, Random.Range(-7, 7), 0);
			}
			
			enemy.GetComponent<Enemy>().gm = this;
		}
	}
}
