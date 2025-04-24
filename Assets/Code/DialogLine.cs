using System.Collections.Generic;
using UnityEngine;

public class DialogLine : MonoBehaviour {
	public string text;
	public string characterName;
	public Sprite characterPortrait;
	public DialogChoice[] choices;
	public DialogLine defaultNextLine;
}
