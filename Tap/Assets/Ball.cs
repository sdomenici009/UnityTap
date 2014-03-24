﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour {
	
	public GameManager gm;
	Vector3 target;
	
	void Start () {
		transform.localScale = new Vector3(.3f, .3f, .3f);
		transform.rotation = new Quaternion(0, 90, 90, 0);
		renderer.material.color  = Color.black;	
		target = new Vector3(25, 25, 0);
	}
	
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{	
			Vector3 temp = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
			
			target = (temp - gameObject.transform.position).normalized * 20;
		}
		
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
