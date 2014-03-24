using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
	
	int score;
	GameObject ball;
	GameObject screenColliders;
	public GameObject wall1, wall2, wall3, wall4;
	public List<GameObject> enemies;
	public GUIStyle style = new GUIStyle();
	Rect textArea = new Rect(Screen.width/2, Screen.height/2,0,0);
	GUIContent scoreText;
	string scoreString;
	
	void OnGUI () {
    	GUI.Label (textArea, score.ToString(), style);
    }
	
	void Start () {
		Random.seed = System.Environment.TickCount;
		wall1.renderer.material.color = Color.black;
		wall2.renderer.material.color = Color.black;
		wall3.renderer.material.color = Color.black;
		wall4.renderer.material.color = Color.black;
		ball = (GameObject)Instantiate(Resources.Load("Ball"));
		ball.GetComponent<Ball>().gm = this;
		enemies = new List<GameObject>();
		score = 0;
		style.fontSize = 15;
		style.alignment = TextAnchor.LowerCenter;
	}
	
	// Update is called once per frame
	void Update () {
		score += 1;
		
		if(score%500 == 0)
		{
			style.fontSize += 20;
			textArea.y += 8;
		}
		
		if(Random.Range(0, 100) == 0 && enemies.Count < 20)
		{
			GameObject enemy = (GameObject)Instantiate(Resources.Load ("Enemy"));
			enemy.GetComponent<Enemy>().gm = this;
			enemies.Add(enemy);
		}
	}
}
