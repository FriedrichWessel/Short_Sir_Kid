using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			GameWorld.Instance.GameEnd(true);
			//Application.LoadLevel(0);
		}
	}
	
}
