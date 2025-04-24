using UnityEngine;
using UnityEngine.Events;

[System.Serializable] //sagt Unity, dass diese Klasse gespeichert werden darf
public class DialogChoice {
	public string name;
	public UnityEvent onChosen;
	public DialogLine nextLine;
}
