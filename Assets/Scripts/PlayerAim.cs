using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
         HandleRotationInput();
    }

    void HandleRotationInput() {
        Vector3 camPos = cam.transform.position;
        transform.LookAt(new Vector3(camPos.x, 1.8672F, camPos.z));
    }
}
