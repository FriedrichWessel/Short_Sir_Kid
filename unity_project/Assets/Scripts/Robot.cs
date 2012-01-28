using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	private float generalMoveSpeed;
	private float currentSpeed;
	private float jumpHeight;
	private float gravity;
	private float jumpingGravity;
	private float increaseSteps;
	private float decreaseSteps;
	private float maxSpeed; 
	private float minSpeed;
	private float afterTumblingSpeedUp;
	
	private float targetTumbleTime;
	private float timeTumbling;
	private bool tumbling = false;
	private bool startJump = false;
	private bool jumping = false;
	private AnimatedUVBehaviour movieTexture;
	private int standardFrameRate;
	
	
	public bool AfterTumbling{
		get;
		private set;
	}
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
		jumpingGravity = GameWorld.Instance.JumpGravity;
		currentSpeed = generalMoveSpeed;
		increaseSteps = GameWorld.Instance.SpeedIncreaseStep;
		decreaseSteps = GameWorld.Instance.SpeedDecreaseStep;
		minSpeed = GameWorld.Instance.MinSpeed;
		maxSpeed = GameWorld.Instance.MaxSpeed;
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
		targetTumbleTime = 0;
		timeTumbling = 0;
		lastState = currentState;
		AfterTumbling = false;
		afterTumblingSpeedUp = GameWorld.Instance.AfterTumblingSpeedUp;
		jumping = false;
		movieTexture = gameObject.GetComponent<AnimatedUVBehaviour>() as AnimatedUVBehaviour;
		standardFrameRate = movieTexture.MovieSpeedFPS;
		
		
		
		charControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(tumbling){
			timeTumbling += Time.deltaTime;
			if(timeTumbling >= targetTumbleTime){
				currentSpeed = 0;
				tumbling = false;
				timeTumbling = 0;
			}
		} else if(AfterTumbling){
			//currentSpeed += afterTumblingSpeedUp;
			IncreaseHappyness(afterTumblingSpeedUp);
			if(currentSpeed == minSpeed)
				AfterTumbling = false;
		} 
		else {
			if(!charControler.isGrounded && startJump){
				//Debug.Log("start Jump");
				jumping = true;
				startJump = false;
			} else if(charControler.isGrounded && jumping){
				jumping = false;
			}
				
			calculateDirection();
			move(currentDirection);	
		}
		
	}
	
	private void calculateDirection(){
		currentDirection.x = currentSpeed;
		if(jumping){
			//Debug.Log("Jump Gravity");
			currentDirection.y -= jumpingGravity * Time.deltaTime;
		}else {
			//Debug.Log("normal Grav");
			currentDirection.y -= gravity * Time.deltaTime;
		}
	}
	
	private void move(Vector3 direction){
		
		if(charControler != null){
			charControler.Move(direction * Time.deltaTime);
		}
			
		
	}
	
	public void Jump(){
		if(charControler.isGrounded){
			//Debug.Log("jump");
			currentDirection.y =  jumpHeight;
			startJump = true;
			//jumping = true;
		}
			
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
		//Debug.Log("Decreas Happyness");
		DecreaseHappyness(decreaseSteps);
		
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
		// calculate animation Playback speed
		var diff = (currentSpeed - generalMoveSpeed)*0.1f ;
		diff += 1;
		
		float value = standardFrameRate * diff ;
		
		movieTexture.MovieSpeedFPS = (int)value;
		
		
	}
	
	private void DecreaseSpeed(float difference){
		currentSpeed -= difference;
		if(currentSpeed <= minSpeed)
			currentSpeed = minSpeed;
		
	}
	
	public void Tumble(float time){
		//Debug.Log("Tumble");
		currentSpeed = 0;
		tumbling = true;
	}
	
	private void checkEmotionState(){
		// Just a Dummy
		currentState = GameWorld.Instance.Emotions.GetState(currentSpeed);
		//Debug.Log("currentState: " + currentState);
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
