using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour {
    public PlayerController player;
    private Button goButton;
    private void Start() {
        switch (SceneManager.GetActiveScene().name) {
            case "DesertScene":
                showDesertUI();
                break;
            case "StartScene":
                showStartUI();
                break;
            case "TempleScene":
                showTempleUI();
                break;

        }
    }

    private void Update() {
        Debug.Log(player.isFighting);
    }

    private void showDesertUI() {
        player.isFighting = false;
    }


    private void showStartUI() {
        Button goButton = this.transform.Find("Canvas").transform.Find("GoButton").GetComponent<Button>();
        goButton.onClick.AddListener(()=>loadNextScene("DesertScene"));
        player.isFighting = true;
    }

    private void showTempleUI() {

    }

    private void loadNextScene(string nextScene) {
        SceneManager.LoadScene(nextScene);
    }
}
