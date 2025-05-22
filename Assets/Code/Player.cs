using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	private InputAction moveAction;
	private InputAction interactAction;
	private Transform referenceCamera;

	public PlayerInput input;
	public CharacterController controller;
	public CameraManager cameraManager;
	public Animator animator;

	public Interactable currentInteractable;

	public float speed = 7f;
	public float gravity = 9.81f;
	public float yVelocity;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		interactAction = input.currentActionMap.FindAction("Interact");
		interactAction.performed += OnInteracted;

		referenceCamera = cameraManager.activeCamera.transform;
	}

	private void OnDestroy() {
		interactAction.performed -= OnInteracted;
	}

	private void OnInteracted(InputAction.CallbackContext obj) {
		if(currentInteractable != null) {
			currentInteractable.Interact();
			animator.SetTrigger("interact");
		}
	}

	// Update is called once per frame
	void Update() {
		if(moveAction.WasPressedThisFrame()) {
			referenceCamera = cameraManager.activeCamera.transform;
		}


		Vector2 moveInput = moveAction.ReadValue<Vector2>();

		//das reicht nicht aus
		//Vector3 move = cameraManager.activeCamera.transform.TransformDirection(direction);

		Vector3 forward = Vector3.ProjectOnPlane(referenceCamera.forward, Vector3.up).normalized;
		Vector3 right = Vector3.ProjectOnPlane(referenceCamera.right, Vector3.up).normalized;
		Vector3 direction = right * moveInput.x + forward * moveInput.y; //wie viel auf right + wie viel auf forward


		if(direction != Vector3.zero)
			transform.forward = Vector3.Slerp(transform.forward, direction, 10 * Time.deltaTime);


		direction *= speed;

		//yVelocity = yVelocity - gravity * Time.deltaTime;
		yVelocity -= gravity * Time.deltaTime;

		direction.y = yVelocity;

		if(controller.Move(direction * Time.deltaTime) == CollisionFlags.Below)
			yVelocity = -5;

		//if(controller.isGrounded)
		//	yVelocity = 0;


		animator.SetFloat("speed", Mathf.Abs(moveInput.magnitude * speed));

	}

	private void OnTriggerEnter(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>(); //Interactable Component bei 'other' suchen
		if(interactable != null) { //wenn 'other' kein Interactable hat, ist die Variabel null
			currentInteractable = interactable;
		}
	}

	private void OnTriggerExit(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>(); //Interactable Component bei 'other' suchen
		if(interactable != null) { //wenn 'other' kein Interactable hat, ist die Variabel null
			currentInteractable = null;
		}
	}

}
