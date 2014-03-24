using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public GameManager gm;
	Vector3 target;
	
	void Start () {
		target = new Vector3(Random.Range (-45, 45), Random.Range (-45, 45), 0);
	}
	
	void Update () {
		if(collider.bounds.Intersects(gm.wall1.collider.bounds) || 
		   collider.bounds.Intersects(gm.wall2.collider.bounds))
		{
			target = new Vector3(-target.x, target.y);
		}
		
		if(collider.bounds.Intersects(gm.wall3.collider.bounds) ||
		   collider.bounds.Intersects(gm.wall4.collider.bounds))
		{
			target = new Vector3(target.x, -target.y);
		}
		
		transform.position = Vector3.MoveTowards(transform.position, target, .075f);
	}
}
