using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

	public int increasePercentage = 10;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.IncreaseHappyness(GameWorld.Instance.SpeedUpStep);
			Debug.Log("Speeding up!!");

		}
		// play sound or etc
	}
	
	void OnCollisionEnter( Collision obj ) {
		if( obj.collider.gameObject.tag == "Player" ) {
			robot.IncreaseHappyness(GameWorld.Instance.SpeedUpStep);
			Debug.Log("Speeding up!!");
		}
		// play sound or etc
	}
	
}
