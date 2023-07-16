using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string sceneName;

    private PlayerController player;

    void Start() {
        player = FindAnyObjectByType<PlayerController>();
    }

    public void OnTriggerEnter(Collider coll) {
        if (coll.GetComponent<PlayerController>() != null && FindAnyObjectByType<EnemyController>() == null) {
            player.stagesCleared++;
            SceneManager.LoadScene(sceneName);
        }
    }
}
