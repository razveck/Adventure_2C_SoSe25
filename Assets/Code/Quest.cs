using UnityEngine;
using UnityEngine.Events;

public class Quest : MonoBehaviour {
	public string objective;
	public Quest nextQuest;
	public bool isCompleted;

	public UnityEvent onStarted;
	public UnityEvent onCompleted;

}
