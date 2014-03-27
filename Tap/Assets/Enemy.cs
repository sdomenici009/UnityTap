using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public GameManager gm;
	Vector3 target;
	
	void Start () {
		if(transform.position.x <= 0 && transform.position.y <= 0)
		{
			if(Random.Range (0,2) == 0)
			{
				target = new Vector3(10, Random.Range (-7, 7), 0);
			}
			else
			{
				target = new Vector3(Random.Range (-10, 10), 7, 0);
			}
		}
		else if(transform.position.x >= 0 && transform.position.y <= 0)
		{
			if(Random.Range (0,2) == 0)
			{
				target = new Vector3(-10, Random.Range (-7, 7), 0);
			}
			else
			{
				target = new Vector3(Random.Range (-10, 10), 7, 0);
			}
		}
		else if(transform.position.x <= 0 && transform.position.y >= 0)
		{
			if(Random.Range (0,2) == 0)
			{
				target = new Vector3(10, Random.Range (-7, 7), 0);
			}
			else
			{
				target = new Vector3(Random.Range (-10, 10), -7, 0);
			}
		}
		else if(transform.position.x >= 0 && transform.position.y >= 0)
		{
			if(Random.Range (0,2) == 0)
			{
				target = new Vector3(-10, Random.Range (-7, 7), 0);
			}
			else
			{
				target = new Vector3(Random.Range (-10, 10), -7, 0);
			}
		}
	}
	
	void Update () {
		transform.position = Vector3.MoveTowards(transform.position, target, .075f);
	}
}
