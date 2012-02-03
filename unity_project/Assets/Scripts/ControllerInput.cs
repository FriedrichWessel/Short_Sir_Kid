using UnityEngine;
using System.Collections;

public class ControllerInput : InteractionBehaviour {
	
	private Robot robot;
	private float hitCooldown;
	private float timeSinceLastHit;
	private readonly System.Random random = new System.Random();
	
	void Awake(){
		//random = new System.Random();
	}
	// Use this for initialization
	void Start () {
		robot = GameWorld.Instance.RobotEntity;
		timeSinceLastHit = hitCooldown;
		hitCooldown = GameWorld.Instance.BrakeCoolDownTime;
		
	}
	
	// Update is called once per frame
	void Update () {
		bool crazy = (robot.currentState == EmotionStates.States.TooFast);
		/*if(crazy){
				// Can do some stuff here for not react
			var number = random.Next(0,100);
			if(number <= GameWorld.Instance.PossibilityToJumpWhenCrazy){
				//Debug.Log("Crazy Jump");
				robot.Jump(6);
				//robot.Tumble(4);
			}
			else if(random.Next(0,100) <= GameWorld.Instance.PossibilityToStopWhenCrazy){
				//Debug.Log("Crazy Tumble");
				robot.Tumble(2);
			}
		}*/
		
		if(Input.GetAxis("jump") != 0.0f){
			/*if(crazy){
				var number = random.Next(0,100);
				if(number <= GameWorld.Instance.PossibilityNotToJumpWhenCrazy){
					return;
				}
			}*/
			robot.Jump();
		}
		if(Input.GetAxis("hit") != 0.0f){
			if(timeSinceLastHit < hitCooldown){
				
			} else {
				robot.Hit();
				timeSinceLastHit = 0;
			}
			
		}
		timeSinceLastHit += Time.deltaTime;
	}
	
	public override void Swipe (MouseEventArgs mouse){
		base.Swipe (mouse);
		if(mouse.MoveDirection.y > 0 ){
			// Swipe Down -> punish
			if(timeSinceLastHit < hitCooldown){
				
			} else {
				robot.Hit();
				timeSinceLastHit = 0;
			}
		}
		if(mouse.MoveDirection.y < 0){
			// swipe up -> jump
			robot.Jump();
		}
	}
}
