using UnityEngine;
using System.Collections;

public class ObstacleStopper : MonoBehaviour {

	private Robot robot;
	
	void Start() {
		robot = GameWorld.Instance.RobotEntity;
	}

	public void OnTriggerEnter( Collider obj ) {
		Debug.Log("Hit");
		if( obj.gameObject.tag == "Player" ) {
			robot.Tumble(GameWorld.Instance.TumbleTime);
			//robot.DecreaseHappyness(GameWorld.Instance.MaxSpeed);
			var sound = gameObject.GetComponent<AudioSource>() as AudioSource;
			if(sound != null)
				sound.Play();
		}
	}
	
}
