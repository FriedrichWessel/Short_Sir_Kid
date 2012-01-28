using UnityEngine;
using System.Collections;

public class ObstacleStopper : MonoBehaviour {

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.Tumble(GameWorld.Instance.TumbleTime);
			//robot.DecreaseHappyness(GameWorld.Instance.MaxSpeed);
		}
	}
	
}
