using UnityEngine;
using System.Collections;

public class EnvironmentScript : MonoBehaviour {
	
	public GameObject player;
	
	private GameObject[] platformType1List;

	// Use this for initialization
	void Start () {
		platformType1List = GameObject.FindGameObjectsWithTag("PlatformType1");
	}
	
	// Update is called once per frame
	void Update () {
		// This part can be used for memory optimization
		/*
		foreach(GameObject currentPlatform in platformType1List) {
			if(currentPlatform != null) {
				if( currentPlatform.transform.position.x < player.transform.position.x - 12.5 )
					Destroy(currentPlatform);
			}
		}
		Debug.Log(player.transform.position.x);
		*/
	}
}
