using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveController : MonoBehaviour
{
    private Character _controllCharacter;

    private Vector2 _startPos;
    private Vector2 _curPos;
    private Vector2 _mouseDelta;
    private bool _isPressed;

    private Vector3 _sendVec;

    private void Start()
    {
        _controllCharacter = GetComponent<Character>();
    }

    private void Update()
    {
        if (_isPressed)
        {
            _curPos = GetCursorPos();

            _mouseDelta.x = _curPos.x - _startPos.x;
            _mouseDelta.y = _curPos.y - _startPos.y;

            _sendVec.x = Mathf.Clamp(_mouseDelta.x, -1, 1);
            _sendVec.z = Mathf.Clamp(_mouseDelta.y, -1, 1);
            _sendVec.y = 0;

            _sendVec = Quaternion.Euler(Vector3.up * Camera.main.transform.eulerAngles.y) * _sendVec;

            _controllCharacter.Move(_sendVec);
        }
    }

    public void OnIsPress(InputAction.CallbackContext m_value)
    {
        if (m_value.phase == InputActionPhase.Started)
        {
            _startPos = GetCursorPos();
            _isPressed = true;
        }
        else if (m_value.phase == InputActionPhase.Canceled)
        {
            _isPressed = false;
        }
    }

    private Vector2 GetCursorPos()
    {
        return Camera.main.ScreenToViewportPoint(Input.mousePosition);
    }
}
