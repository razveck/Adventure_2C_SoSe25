using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

//alternativ zur "Quest" Methode
public class QuestManager : MonoBehaviour {

	public Interactable mario;
	public Interactable luigi;
	public GameObject dialogScreen;
	public GameObject questScreen;
	public TextMeshProUGUI questObjective;
	public TextMeshProUGUI questGoal;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	IEnumerator Start() {

		yield return WaitForNPC(mario);
		yield return new WaitWhile(() => dialogScreen.activeSelf);

		questScreen.SetActive(true);
		questObjective.text = "Talk to Luigi";

		Debug.Log("Mario");

		yield return WaitForNPC(luigi);
		yield return new WaitWhile(() => dialogScreen.activeSelf);
		questObjective.text = "Talk to Mario";

		yield return WaitForNPC(mario);
		yield return new WaitWhile(() => dialogScreen.activeSelf);

		Debug.Log("Quest end");
	}

	IEnumerator WaitForNPC(Interactable interactable) {
		bool talked = false;
		UnityAction action = () => talked = true;

		interactable.interacted.AddListener(action);
		yield return new WaitUntil(() => talked);
		interactable.interacted.RemoveListener(action);
	}

	IEnumerator WaitForDialog(DialogLine dialog) {
		bool talked = false;
		UnityAction action = () => talked = true;

		dialog.onShow.AddListener(action);
		yield return new WaitUntil(() => talked);
		dialog.onShow.RemoveListener(action);
	}

	IEnumerator WaitForItems(Interactable[] interactables, int goal) {
		int counter = 0;
		UnityAction action = () => {
			counter++;
			questGoal.text = counter + "/" + goal;
		};

		for(int i = 0; i < interactables.Length; i++) {
			interactables[i].interacted.AddListener(action);
		}
		yield return new WaitUntil(() => counter == goal);
		for(int i = 0; i < interactables.Length; i++) {
			interactables[i].interacted.RemoveListener(action);
		}
	}

	/* coroutine beispiel
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(TestCoroutine());
		}

		if(Input.GetKeyDown(KeyCode.X)){
			StopAllCoroutines();
			//StopCoroutine()
		}
	}

	IEnumerator TestCoroutine() {
		for(int i = 0; i < 100000; i++) {
			yield return new WaitForEndOfFrame(); //implizit Ende des nächsten Frames
			Debug.Log(i);
		}
	}
	*/
}


/*inheritance
class Animal {
	public string name;
}

class Dog : Animal {

}

class Cat : Animal {
	public void Meow() {

	}
}

class Tiger : Cat {

}

class Example {

	void Bla() {
		Tiger t = new Tiger();
		t.name = "TTT";
		t.Meow();
	}

}
*/