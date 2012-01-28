using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	private float generalMoveSpeed;
	private float currentSpeed;
	private float jumpHeight;
	private float gravity;
	private float increaseSteps;
	private float maxSpeed; 
	private float minSpeed;
	
	private CharacterController charControler;
	
	private Vector3 currentDirection;
	//private CharacterController charControler;
	// Use this for initialization
	void Start () {
		Debug.Log("Start Robot");
		generalMoveSpeed = GameWorld.Instance.MoveSpeed;
		jumpHeight = GameWorld.Instance.JumpHeight;
		currentDirection = new Vector3(generalMoveSpeed,0,0);
		gravity = GameWorld.Instance.Gravity;
		currentSpeed = generalMoveSpeed;
		increaseSteps = GameWorld.Instance.SpeedStep;
		minSpeed = GameWorld.Instance.MinSpeed;
		maxSpeed = GameWorld.Instance.MaxSpeed;
		
		charControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		calculateDirection();
		move(currentDirection);
	}
	
	private void calculateDirection(){
		currentDirection.x = currentSpeed;
		currentDirection.y -= gravity * Time.deltaTime;
	}
	
	private void move(Vector3 direction){
		
		if(charControler != null){
			charControler.Move(direction * Time.deltaTime);
		}
			
		
	}
	
	public void Jump(){
		if(charControler.isGrounded)
			currentDirection.y =  jumpHeight;
	}
	
	public void IncreaseHappyness(){
		IncreaseHappyness(increaseSteps);
		// later we do some graphic changes here
	}
	
	public void DecreaseHappyness(){
		Debug.Log("Decreas Happyness");
		DecreaseHappyness(increaseSteps);
		// later we do some graphic changes here
	}
	
	public void IncreaseHappyness(float changeValue){
		IncreaseSpeed(changeValue);
	}
	
	public void DecreaseHappyness(float changeValue){
		DecreaseSpeed(changeValue);
	}
	
	private void IncreaseSpeed(float difference){
		currentSpeed += difference;
		if(currentSpeed >= maxSpeed)
			currentSpeed = maxSpeed;
		checkEmotionState();
	}
	
	private void DecreaseSpeed(float difference){
		currentSpeed -= difference;
		if(currentSpeed <= minSpeed)
			currentSpeed = minSpeed;
		checkEmotionState();
	}
	
	private void checkEmotionState(){
		// Just a Dummy
	}
	
}
