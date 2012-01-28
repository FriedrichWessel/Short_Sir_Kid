using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	private Robot robot;

	// Use this for initialization
	void Start () {
		robot = GameWorld.Instance.RobotEntity;
	}
	
	// Update is called once per frame
	void Update () {
		Camera.mainCamera.transform.position = new Vector3(robot.transform.position.x,
															5,
															robot.transform.position.z - 15);
	}
}
