using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	private float generalMoveSpeed;
	private float currentSpeed;
	private float jumpHeight;
	private float gravity;
	private float increaseSteps;
	private float decreaseSteps;
	private float maxSpeed; 
	private float minSpeed;
	
	public EmotionStates.States currentState{
		get;
		private set;
	} 
	private EmotionStates.States lastState;
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
		increaseSteps = GameWorld.Instance.SpeedIncreaseStep;
		decreaseSteps = GameWorld.Instance.SpeedDecreaseStep;
		minSpeed = GameWorld.Instance.MinSpeed;
		maxSpeed = GameWorld.Instance.MaxSpeed;
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
		lastState = currentState;
		
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
	
	public void Hit(){
		if(GameWorld.Instance.Emotions.GetState(currentSpeed) == EmotionStates.States.TooFast)
			currentSpeed = GameWorld.Instance.Emotions.GetStateSpeed(EmotionStates.States.TooSlow);
		else 
			DecreaseHappyness(decreaseSteps);
	}
	public void IncreaseHappyness(){
		IncreaseHappyness(increaseSteps);
	}
	
	public void DecreaseHappyness(){
<<<<<<< HEAD
		//Debug.Log("Decreas Happyness");
		DecreaseHappyness(decreaseSteps);
=======
		Debug.Log("Decreas Happyness");
		DecreaseHappyness(increaseSteps);
>>>>>>> arda
		
	}
	
	public void IncreaseHappyness(float changeValue){
		IncreaseSpeed(changeValue);
		checkEmotionState();
	}
	
	public void DecreaseHappyness(float changeValue){
		DecreaseSpeed(changeValue);
		checkEmotionState();
	}
	
	private void IncreaseSpeed(float difference){
		currentSpeed += difference;
		if(currentSpeed >= maxSpeed)
			currentSpeed = maxSpeed;
		
	}
	
	private void DecreaseSpeed(float difference){
		currentSpeed -= difference;
		if(currentSpeed <= minSpeed)
			currentSpeed = minSpeed;
		
	}
	
	private void checkEmotionState(){
		// Just a Dummy
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
<<<<<<< HEAD
		//Debug.Log("currentState: " + currentState);
=======
		Debug.Log("currentState: " + currentState);
>>>>>>> arda
		if(lastState != currentState){
			if(currentState == EmotionStates.States.TooFast){
				Debug.Log("Reached To Fast");
				IncreaseSpeed(maxSpeed);
				// Do Graphic Changes here
			} else if(currentState == EmotionStates.States.TooSlow){
				Debug.Log("Reached Too Slow");
				DecreaseSpeed(maxSpeed);
				// Do Graphic Changes here
			}
				
			lastState = currentState ;	
		}
		
		
	}
	
}
