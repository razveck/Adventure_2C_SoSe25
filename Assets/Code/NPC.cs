using UnityEngine;

public class NPC : MonoBehaviour {

	public DialogLine nextLine;
	public DialogScreen dialogScreen;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//GetComponent<Interactable>().interacted.AddListener(StartDialog);
	}


	public void StartDialog(){
		dialogScreen.ShowDialog(nextLine);
	}
}
