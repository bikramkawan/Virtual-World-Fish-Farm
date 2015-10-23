using UnityEngine;
using System.Collections;

public class FishMovements : MonoBehaviour {
	
	public Vector3 startingPoint;
	public float maxDist;
	public Vector3 rndShift;
	public float stepSize = 0.1f;
	public float eatRate = 0.1f;
	public float planesize=460f;

	// Use this for initialization
	void Start () {
		
		startingPoint = transform.position*1f;
		rndShift = startingPoint + maxDist * Random.insideUnitSphere;

		rndShift.y = startingPoint.y;

	
		
	
	}
	
	// Update is called once per frame
	void Update () {


//		float xpos, zpos;
//		xpos = transform.position.x + 1f * stepSize;
//		zpos = transform.position.z + 1f * stepSize;
//		if (xpos > planesize) {// periodic boundary
//			xpos-=planesize;
//		}
//		else if (xpos < -planesize) {
//			xpos+=planesize;
//		}
//		else if (zpos > planesize) {
//			zpos-=planesize;
//		}
//		else if (zpos < -planesize) {
//			zpos+=planesize;
//		}
//		transform.position = new Vector3 (xpos, transform.position.y, zpos);
////			
		
		if ( Vector3.Distance ( transform.position, rndShift ) > 0.1f )
		{
			transform.position = Vector3.MoveTowards( transform.position, rndShift, Time.deltaTime );			
			//Quaternion targRot = Quaternion.LookRotation( rndShift  - transform.position );
			//transform.rotation = Quaternion.Lerp( transform.rotation, targRot, Time.deltaTime );			
		}
		else
		{
			rndShift = startingPoint + maxDist * Random.insideUnitSphere;
			rndShift.y = startingPoint.y;
		}
	
	}
		
	 void OnCollisionEnter(Collision collision) {
	
		//Debug.Log("Collision");
		
		foreach (ContactPoint contact in collision.contacts)
		{
			rndShift = maxDist * contact.normal;
			rndShift.y = startingPoint.y;        
        }
		
		
		
	}	

}
