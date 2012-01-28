using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {
	
	private Robot robot;
	// Use this for initialization
	void Start () {
		robot = GameWorld.Instance.RobotEntity;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("jump") != 0.0f){
			robot.Jump();
		}
		if(Input.GetAxis("hit") != 0.0f){
			robot.DecreaseHappyness();
		}
	}
}