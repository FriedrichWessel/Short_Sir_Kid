using UnityEngine;
using System.Collections;

public class Hazard : MonoBehaviour {

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		
		if( obj.gameObject.tag == "Player" ) {
			gameObject.renderer.enabled = false;
			GameWorld.Instance.GameEnd(false, 0.5f);
			GameWorld.Instance.RobotEntity.Tumble(3);
			Detonator boom = gameObject.GetComponentInChildren<Detonator>() as Detonator;
			if(boom != null)
				boom.Explode();
		}
	}
	
}
