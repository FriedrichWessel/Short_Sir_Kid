using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour {

	private float moveSpeed;
	private float jumpHeight;
	private float gravity;
	
	private CharacterController charControler;
	
	private Vector3 currentDirection;
	//private CharacterController charControler;
	// Use this for initialization
	void Start () {
		Debug.Log("Start Robot");
		moveSpeed = GeneralValues.Instance.MoveSpeed;
		jumpHeight = GeneralValues.Instance.JumpHeight;
		currentDirection = new Vector3(moveSpeed,0,0);
		gravity = GeneralValues.Instance.Gravity;
		
		charControler = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//var direction = new  Vector3(moveSpeed, 0, 0 );
		calculateDirection();
		move(currentDirection);
	}
	
	private void calculateDirection(){
		currentDirection.x = moveSpeed;
		currentDirection.y -= gravity * Time.deltaTime;
		/*Debug.Log("Time Delta: " + Time.deltaTime);
		Debug.Log("Move Speed: " + moveSpeed);
		Debug.Log ("CurrentDirection("+currentDirection.x+"," + currentDirection.y+","+currentDirection.z+")");*/
		
		//currentDirection = currentDirection * Time.deltaTime;
	}
	
	private void move(Vector3 direction){
		//gameObject.transform.Translate(direction);
		
		if(charControler != null){
			//Debug.Log("Move the Guy" + direction.x + " " + direction.y + " " + direction.z);	
			charControler.Move(direction * Time.deltaTime);
			
		}
			
		
	}
	
	public void Jump(){
		if(charControler.isGrounded)
			currentDirection.y =  jumpHeight;
	}
}
