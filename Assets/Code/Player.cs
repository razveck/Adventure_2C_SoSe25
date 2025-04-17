using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	private InputAction moveAction;
	private Transform referenceCamera;

	public PlayerInput input;
	public CharacterController controller;
	public CameraManager cameraManager;

	public float speed = 7f;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		referenceCamera = cameraManager.activeCamera.transform;
	}

	// Update is called once per frame
	void Update() {
		if(moveAction.WasPressedThisFrame()){
			referenceCamera = cameraManager.activeCamera.transform;
		}


		Vector2 moveInput = moveAction.ReadValue<Vector2>();

		//das reicht nicht aus
		//Vector3 move = cameraManager.activeCamera.transform.TransformDirection(direction);

		Vector3 forward = Vector3.ProjectOnPlane(referenceCamera.forward, Vector3.up).normalized;
		Vector3 right = Vector3.ProjectOnPlane(referenceCamera.right, Vector3.up).normalized;
		Vector3 direction = right * moveInput.x + forward * moveInput.y; //wie viel auf right + wie viel auf forward

		controller.Move(direction * speed * Time.deltaTime);

		if(direction != Vector3.zero)
			transform.forward = Vector3.Slerp(transform.forward, direction, 10 * Time.deltaTime);
		
	}
}
