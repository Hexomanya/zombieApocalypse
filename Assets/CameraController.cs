using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Keybinding Settings")]
    [SerializeField] private KeyCode keyUpKeyCode = KeyCode.W;
    [SerializeField] private KeyCode keyDownKeyCode = KeyCode.S;
    [SerializeField] private KeyCode keyLeftKeyCode = KeyCode.A;
    [SerializeField] private KeyCode keyRightKeyCode = KeyCode.D;

    [Header("Movement Settings")]
    [SerializeField] private float cameraSpeed = 5f;
    [SerializeField] private float scrollSpeed = 2f;

    private Camera cameraComponent;

    private void Start()
    {
        cameraComponent = this.GetComponent<Camera>();
        if(cameraComponent == null)
        {
            Debug.LogError("CameraController: Could not find Camera Component.");
        }
    }
    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 moveVector = Vector3.zero;
        if (Input.GetKey(keyUpKeyCode)) { moveVector += Vector3.up; }
        if (Input.GetKey(keyDownKeyCode)) { moveVector += Vector3.down; }
        if (Input.GetKey(keyLeftKeyCode)) { moveVector += Vector3.left; }
        if (Input.GetKey(keyRightKeyCode)) { moveVector += Vector3.right; }

        this.transform.position += moveVector * cameraSpeed * Time.deltaTime;
    }

    private void HandleZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            cameraComponent.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
    }
}
