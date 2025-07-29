using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _lookSensitivity = 2f;
    private Camera _playerCamera;
    private Rigidbody _rb;

    private float _verticalRotation = 0f;
    private Vector3 _movementVect = Vector3.zero;

    void Start()
    {
        _playerCamera = GetComponentInChildren<Camera>();
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _lookSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _lookSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        _verticalRotation -= mouseY;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -90, 90f);
        _playerCamera.transform.localEulerAngles = new Vector3(_verticalRotation, 0f, 0f);

        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        _movementVect = (transform.right * horizontalAxis + transform.forward * verticalAxis).normalized;
    }

    private void FixedUpdate()
    {
        Vector3 moveDelta = _movementVect * _moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + moveDelta);
    }
}
