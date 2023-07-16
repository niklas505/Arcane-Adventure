using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour {
    public PlayerController player;
    private Vector3[] spawningSpots = new Vector3[6];
    public GameObject selectedCreatures;

    private void Start() {
        getSpawningCoordinations();
        spawnCreatures();
    }

    private void Update() {
        player.isFighting = true;
    }

    private void spawnCreatures() {
        for (int i = 0; i < 6; i++) {
            GameObject instantiatedObject = Instantiate(selectedCreatures, spawningSpots[i], Quaternion.identity);
            instantiatedObject.transform.LookAt( new Vector3(this.transform.GetChild(0).transform.position.x,0, this.transform.GetChild(0).transform.position.z));

        }
    }

    private void getSpawningCoordinations() {
        for (int i = 0; i < 6; i++) {
            spawningSpots[i] = this.transform.GetChild(i + 1).transform.position;
            spawningSpots[i].y += this.transform.GetChild(i + 1).transform.localScale.y;
        }
    }
}
