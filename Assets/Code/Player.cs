using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	InputAction moveAction;

	public PlayerInput input;
	public CharacterController controller;

	public float speed = 7f;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
	}

	// Update is called once per frame
	void Update() {
		Vector2 moveInput = moveAction.ReadValue<Vector2>();
		Vector3 direction = new(moveInput.x, 0f, moveInput.y);

		controller.Move(direction * speed * Time.deltaTime);
	}
}
