using UnityEngine;
using System.Collections;

public class ObstacleStopper : MonoBehaviour {
	
	public int decreasePercentage = 90;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.DecreaseHappyness(decreasePercentage);
		}
	}
	
}
