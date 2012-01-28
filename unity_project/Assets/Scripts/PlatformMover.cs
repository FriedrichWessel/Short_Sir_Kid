using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour {
	// TODO make the movement smooth
	
	public Transform pointA;
	public Transform pointB;
	// if isLoop is true, object goes from pointA to pointB, then pointB to pointA infinitely.
	// if isLoop is false, object goes from pointA to pointB, then stops.
	public bool isLoop;
	// speed of moving platform
	public float speed;
	
	// is the platform moving
	private bool isMoving = false;
	// is the platform on pointA and pointB
	private bool isOnPointA = true;
	private bool isOnPointB = false;
	// if isTriggered is true, moving starts
	private bool isTriggered;

	void Start () {
		// initialize the position of moving platform
		gameObject.transform.position = pointA.transform.position;
		isTriggered = false;
	}
	
	// Trigger is called by PlatformTrigger
	public void Trigger() {
		isTriggered = true;
	}
	
	private void moveFromAtoB(){
		gameObject.transform.position = new Vector3(
						Mathf.MoveTowards(transform.position.x, pointB.transform.position.x, speed * Time.deltaTime),
						Mathf.MoveTowards(transform.position.y, pointB.transform.position.y, speed * Time.deltaTime),
						Mathf.MoveTowards(transform.position.z, pointB.transform.position.z, speed * Time.deltaTime));
	}
	
	private void moveFromBtoA(){
		gameObject.transform.position = new Vector3(
						Mathf.MoveTowards(transform.position.x, pointA.transform.position.x, speed * Time.deltaTime),
						Mathf.MoveTowards(transform.position.y, pointA.transform.position.y, speed * Time.deltaTime),
						Mathf.MoveTowards(transform.position.z, pointA.transform.position.z, speed * Time.deltaTime));
	}
	
	private void checkDirection(){
		/* TODO code it ;) */
	}
	
	void Update () {
		if( isTriggered ) {
			if( isLoop ) {
				// Loop from pointA to pointB, then pointB to pointA
				checkDirection();
			} else {
				// Move from pointA to pointB
				moveFromAtoB();
			}
		}
	}
	
}
