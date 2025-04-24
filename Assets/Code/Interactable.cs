using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	//C# event
	//public event System.Action interactedCS;

	//Unity events
	public UnityEvent interacted;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//subscribing, adding listener, etc
		//interactedCS += Bla;
		//interacted.AddListener(Bla);
		//interacted.RemoveListener(Bla);
		//void Bla() {
		//	Debug.Log("Bla");
		//}
	}


	public void Interact() {
		//event auslösen
		//interactedCS.Invoke();
		interacted.Invoke();
	}
}
