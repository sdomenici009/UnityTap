using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	GameObject ball;
	GameObject screenColliders;
	public GameObject wall1, wall2, wall3, wall4;
	
	void Start () {
		Random.seed = System.Environment.TickCount;
		wall1.renderer.material.color = Color.black;
		wall2.renderer.material.color = Color.black;
		wall3.renderer.material.color = Color.black;
		wall4.renderer.material.color = Color.black;
		ball = (GameObject)Instantiate(Resources.Load("Ball"));
		ball.GetComponent<Ball>().gm = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(Random.Range(0, 100) == 0)
		{
			GameObject enemy = (GameObject)Instantiate(Resources.Load ("Enemy")); 
			enemy.GetComponent<Enemy>().gm = this;
		}
	}
}
