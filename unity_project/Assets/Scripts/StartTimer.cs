using UnityEngine;
using System.Collections;

public class StartTimer : InteractionBehaviour {
	
		public int LoadLevel = 0;
	public int LoadLevelMobile = 0;


		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("jump") != 0)
			Application.LoadLevel(LoadLevel);
	}
	
	public override void Click (MouseEventArgs mouse){
		base.Click (mouse);
#if UNITY_IPHONE || UNITY_ANDROID
		Application.LoadLevel(LoadLevelMobile);
#endif
	}
}
