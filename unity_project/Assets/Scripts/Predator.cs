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
		// here enum checks
		if (obj.gameObject.tag == "Player") {
			Debug.Log("YouSuck!");
			//Time.timeScale = 0;
			Application.LoadLevel(0);
		}
	}
	
	
}
