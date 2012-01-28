using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {
	
	private Robot robot;
	private float hitCooldown;
	private float timeSinceLastHit;
	
	// Use this for initialization
	void Start () {
		robot = GameWorld.Instance.RobotEntity;
		timeSinceLastHit = hitCooldown;
		hitCooldown = GameWorld.Instance.BrakeCoolDownTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(robot.currentState == EmotionStates.States.TooFast){
				// Can do some stuff here for not react
		}
		
		if(Input.GetAxis("jump") != 0.0f){
			robot.Jump();
		}
		if(Input.GetAxis("hit") != 0.0f){
			if(timeSinceLastHit < hitCooldown){
				
			} else {
				robot.DecreaseHappyness();
				timeSinceLastHit = 0;
			}
			
		}
		timeSinceLastHit += Time.deltaTime;
	}
}
