using UnityEngine;
using System.Collections;

public class ObstacleSlowerHard : MonoBehaviour {

	public int decreasePercentage = 40;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.DecreaseHappyness(GameWorld.Instance.HardStopperStep);
		}
	}
	
}
