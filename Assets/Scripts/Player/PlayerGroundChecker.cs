using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput.actions["ActionKey"].performed += ctx => ActionKey(true);
        _playerInput.actions["ActionKey"].canceled += ctx => ActionKey(false);
    }

    private void ActionKey(bool pressedKey)
    {
        Debug.Log($"ActionKey = {pressedKey}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log($"OnTriggerEnter = {other.name}");
            transform.parent.SetParent(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
        {
            Debug.Log($"OnTriggerExit = {other.name}");
            transform.parent.SetParent(null);
        }
    }
}