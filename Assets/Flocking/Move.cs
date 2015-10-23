using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {
	
	//Move target around circle with tangential speed
	//public GameObject Agent;
	public float tangentialSpeed;//m/s
	public float circumference;//m
	public float targetRadius;//m
	public float period;//s
	public float angularSpeed;//rad/s
	public float currentAngle;//rad/s
	Vector3 Centre = new Vector3();
	
	//Use this for intialization
	void Start(){
		tangentialSpeed = 2f;
		circumference = 50f;
		targetRadius = 2*circumference/(2*Mathf.PI);
		period = circumference/tangentialSpeed;
		angularSpeed = Mathf.PI/period;
		currentAngle = 0f;
		//Centre = new Vector3(493f,24,530);	
	}
	void Update(){
		transform.localPosition =  targetRadius*(new Vector3(Mathf.Sin (currentAngle),0,Mathf.Cos (currentAngle)));
		currentAngle += angularSpeed*Time.deltaTime;
		if(currentAngle>2*Mathf.PI){
			currentAngle = currentAngle-2*Mathf.PI;
		}
	}
}