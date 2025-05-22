using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScreen : MonoBehaviour {

	private Quest currentQuest;
	//private List<Quest> currentQuests;

	public TextMeshProUGUI objectiveText;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//beispiel List
		//currentQuests.Add(...);
		//currentQuests.Remove(...);
		//for(int i = 0; i < currentQuests.Count; i++) {
		//	Debug.Log(currentQuests[i].objective);
		//	objectiveText.text += currentQuests[i].objective;
		//}
		//currentQuests[0].name = "";
	}

	public void StartQuest(Quest quest){
		if(quest.isCompleted || quest == currentQuest)
			return; //funktion abbrechen


		currentQuest = quest;
		objectiveText.text = quest.objective;
		quest.onStarted.Invoke();

		gameObject.SetActive(true);
	}

	public void EndQuest(Quest quest){
		if(quest.isCompleted || quest != currentQuest)
			return; //funktion abbrechen

		quest.isCompleted = true;
		quest.onCompleted.Invoke();
		if(quest.nextQuest == null){
			gameObject.SetActive(false);
		} else{
			StartQuest(quest.nextQuest);
		}
	}
}
