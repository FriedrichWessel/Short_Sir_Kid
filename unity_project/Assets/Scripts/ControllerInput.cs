using UnityEngine;
using System.Collections;

public class ControllerInput : MonoBehaviour {
	
	private Robot robot;
	// Use this for initialization
	void Start () {
		robot = GeneralValues.Instance.RobotEntity;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("jump") != 0.0f){
			Debug.Log("Jump");
			robot.Jump();
		}
		Debug.Log("Jump is: " + Input.GetAxis("jump"));
	}
}
