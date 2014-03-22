using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	GameObject ball;
	Vector3 startDestination;
	GameObject screenColliders;
	public GameObject wall1, wall2, wall3, wall4;
	
	void Start () {
		Random.seed = System.Environment.TickCount;
		ball = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		startDestination = new Vector3(Random.Range(50, 100), Random.Range(50, 100), 0);
		ball.renderer.material.color  = Color.black;
		wall1.renderer.material.color = Color.black;
		wall2.renderer.material.color = Color.black;
		wall3.renderer.material.color = Color.black;
		wall4.renderer.material.color = Color.black;	
	}
	
	void Update () {
		if(ball.collider.bounds.Intersects(wall1.collider.bounds) || 
		   ball.collider.bounds.Intersects(wall2.collider.bounds))
		{
			startDestination = new Vector3(-startDestination.x, startDestination.y);
		}
		
		if(ball.collider.bounds.Intersects(wall3.collider.bounds) ||
		   ball.collider.bounds.Intersects(wall4.collider.bounds))
		{
			startDestination = new Vector3(startDestination.x, -startDestination.y);
		}
		
		ball.transform.position = Vector3.MoveTowards(ball.transform.position, startDestination, .1f);
	}
}
