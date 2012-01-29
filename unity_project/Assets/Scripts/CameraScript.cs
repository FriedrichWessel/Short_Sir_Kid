using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	
	private Robot robot;
	private Camera cam;

	// Use this for initialization
	void Start () {
		robot = GameWorld.Instance.RobotEntity;
		cam = Camera.mainCamera;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		cam.transform.position = new Vector3(robot.transform.position.x+5,
															cam.transform.position.y,
															cam.transform.position.z);
	}
}
