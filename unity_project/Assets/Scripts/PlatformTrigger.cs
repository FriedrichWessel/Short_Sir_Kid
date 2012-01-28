using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {
	
	public PlatformMover platformMover;
	
	public void OnTriggerEnter( Collider obj ) {
		if( obj.gameObject.tag == "Player" ) {
			platformMover.Trigger();
		}
	}
	
}
