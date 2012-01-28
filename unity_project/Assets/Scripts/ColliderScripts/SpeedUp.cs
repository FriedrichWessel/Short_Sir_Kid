using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	public int increasePercentage = 10;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.IncreaseHappyness(GameWorld.Instance.SpeedUpStep);
		}
		// play sound or etc
	}
	
}
