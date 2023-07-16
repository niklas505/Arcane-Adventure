using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue_Manager : MonoBehaviour {
    public PlayerController player;
    public List<string> Story1;
    private IEnumerator<string> iterator;
    private Canvas canvas;
    private Button nextButton;
   
    void Start() {
        iterator = Story1.GetEnumerator();
        canvas = this.GetComponent<Canvas>();
        iterator.MoveNext();
        updateText();
    }

    public void handleNextButton() {
        if (iterator != null) {
            if (iterator.Current == Story1[Story1.Count - 1]) {
                Destroy(this.transform.Find("TextContainer").gameObject);
                if (SceneManager.GetActiveScene().name == "StartScene") {
                    this.transform.Find("GoButton").GetComponent<Button>().gameObject.SetActive(true);
                }
            }
            else {
                iterator.MoveNext();
                updateText();
            }
        }
    }

    private void updateText() {
        Text textComponent = this.transform.Find("TextContainer").transform.Find("Text").GetComponent<Text>();
        textComponent.text = "";

        StartCoroutine(TypeText(iterator.Current, textComponent));
    }

    private IEnumerator TypeText(string text, Text textComponent) {
        Button nextButton = this.transform.Find("TextContainer").transform.Find("NextButton").GetComponent<Button>();
        nextButton.gameObject.SetActive(false);
        foreach (char letter in text.ToCharArray()) {
            textComponent.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        nextButton.gameObject.SetActive(true);
    }
}