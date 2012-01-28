using UnityEngine;
using System.Collections;

public class ObstacleSlowerSoft : MonoBehaviour {
	
	public int decreasePercentage = 20;

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			robot.DecreaseHappyness(GameWorld.Instance.SoftStopperStep);
		}
	}
	
}
