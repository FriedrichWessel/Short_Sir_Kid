using UnityEngine;
using System.Collections;

public class Burstable : MonoBehaviour {

	public int increasePercentage = 2;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.IncreaseHappyness(GameWorld.Instance.BurstSlowDownStep);
		}
		// play destroy animation
	}
	
}
