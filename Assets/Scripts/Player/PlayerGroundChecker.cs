using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGroundChecker : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private IGameStatus _gameStatus;

    private void Start()
    {
        _playerInput.actions["ActionKey"].performed += ctx => ActionKey(true);
        _playerInput.actions["ActionKey"].canceled += ctx => ActionKey(false);

        _gameStatus = ServiceLocator.GetService<IGameStatus>();
    }

    private void ActionKey(bool pressedKey)
    {
        Debug.Log($"ActionKey = {pressedKey}");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"OnTriggerEnter = {other.name}");
        if (other.CompareTag("Platform"))
        {
            transform.parent.SetParent(other.transform);
        } 
        else if (other.CompareTag("Dead"))
        {
            Debug.Log("Dead");
            _gameStatus.InvokePlayerDeadEvent();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log($"OnTriggerExit = {other.name}");
        if (other.CompareTag("Platform"))
        {
            transform.parent.SetParent(null);
        }
    }
} 