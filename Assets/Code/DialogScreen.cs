using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

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

		input.SwitchCurrentActionMap("UI");
	}

	public void SelectChoice(int index) {
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
