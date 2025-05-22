using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogLine : MonoBehaviour {
	public string text;
	public string characterName;
	public Sprite characterPortrait;
	public DialogChoice[] choices;
	public DialogLine defaultNextLine;
	public UnityEvent onShow;
}
