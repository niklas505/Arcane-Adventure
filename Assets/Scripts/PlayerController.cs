using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float movSpeed = 5f;
    private Animator animator;
    private string IS_WALKING = "isWalking";
    public Camera mainCamera;
    public Vector3 moveDir = new Vector3 (0f,0f,0f);
    public bool isFighting;
    public List<string> earnedCards;
    public List<string> earnedCreatures;
    public List<string> selectedCreatures;
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
    }
    private void Update() {
        HandleCursor();
        HandleMovementInput();
    }

    void HandleCursor() {
        if (isFighting) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void HandleMovementInput() {
        if (isFighting) return;
        float vertical = 0f;
        float horizontal = 0f;

        if (Input.GetKey(KeyCode.W)) {
            vertical = +1;
        }
        if (Input.GetKey(KeyCode.S)) {
            vertical = -1;
        }

        if (Input.GetKey(KeyCode.A)) {
            horizontal = -1;
        }

        if (Input.GetKey(KeyCode.D)) {
            horizontal = +1;
        }

        Vector3 cameraForward = mainCamera.transform.forward;
        Vector3 cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();
        
        moveDir = cameraForward*vertical +cameraRight*horizontal;
        moveDir.Normalize();

        bool canMove = !Physics.Raycast(transform.position, moveDir, .7f);

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)) {
            animator.SetBool(IS_WALKING, true);
        }
        else {
            animator.SetBool(IS_WALKING, false);
        }
        if (canMove){
            transform.position += moveDir *movSpeed *Time.deltaTime;
        }
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }
}
