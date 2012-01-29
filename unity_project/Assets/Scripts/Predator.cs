using UnityEngine;
using System.Collections;

public class Predator : MonoBehaviour {
	
	
	private float moveSpeed;
	
	// Use this for initialization
	void Start () {
		moveSpeed = GameWorld.Instance.PredatorSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {
		var direction = new Vector3(moveSpeed,0,0);
		gameObject.transform.Translate(direction * Time.deltaTime);
	}
	
	void OnTriggerEnter( Collider obj ) {
		if (obj.gameObject.tag == "Player") {
			GameWorld.Instance.RobotEntity.Die();
			GameWorld.Instance.GameEnd(false,2.5f);
		}
	}
	
	
}
