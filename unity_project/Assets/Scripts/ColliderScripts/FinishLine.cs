using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
	Debug.Log("Win");
		if( obj.gameObject.tag == "Player" ) {
			GameWorld.Instance.GameEnd(true,1);
			//Application.LoadLevel(0);
		}
	}
	
}
