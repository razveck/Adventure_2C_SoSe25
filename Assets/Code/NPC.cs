using UnityEngine;

public class NPC : MonoBehaviour {

	public DialogLine nextLine;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//GetComponent<Interactable>().interacted.AddListener(StartDialog);
	}


	public void StartDialog(){
		Debug.Log("Dialog");
	}
}
