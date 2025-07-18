using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

	private Coroutine typewriter;
	private DialogLine currentDialog;

	public TextMeshProUGUI dialogText;
	public TextMeshProUGUI charNameText;
	public Image portrait;
	public Button[] choiceButtons;
	public Button continueButton;

	public PlayerInput input;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void ShowDialog(DialogLine dialog) {
		currentDialog = dialog;
		dialog.onShow.Invoke();

		dialogText.text = dialog.text;
		charNameText.text = dialog.characterName;
		portrait.sprite = dialog.characterPortrait;

		for(int i = 0; i < choiceButtons.Length; i++) {
			if(i < dialog.choices.Length) {
				choiceButtons[i].gameObject.SetActive(true);
				choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialog.choices[i].name;
			} else {
				choiceButtons[i].gameObject.SetActive(false);
			}
		}

		if(dialog.choices.Length == 0) {
			continueButton.gameObject.SetActive(true);
			EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
		} else {
			continueButton.gameObject.SetActive(false);
			EventSystem.current.SetSelectedGameObject(choiceButtons[0].gameObject);
		}


		gameObject.SetActive(true);
		//StopAllCoroutines();
		if(typewriter != null)
			StopCoroutine(typewriter);

		typewriter = StartCoroutine(TypewriterCoroutine());

		input.SwitchCurrentActionMap("UI");
	}

	IEnumerator TypewriterCoroutine(){
		dialogText.maxVisibleCharacters = 0;
		for(int i = 0; i < dialogText.text.Length; i++) {
			dialogText.maxVisibleCharacters++;
			yield return new WaitForSecondsRealtime(0.05f);
		}

		dialogText.maxVisibleCharacters = 99999999;
	}

	public void SelectChoice(int index) {
		currentDialog.choices[index].onChosen.Invoke();
		ShowDialog(currentDialog.choices[index].nextLine);
	}

	public void Continue() {
		if(currentDialog.defaultNextLine != null)
			ShowDialog(currentDialog.defaultNextLine);
		else {
			EndDialog();
		}
	}

	public void EndDialog() {
		gameObject.SetActive(false);
		input.SwitchCurrentActionMap("Player");
	}
}
