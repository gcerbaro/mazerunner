using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IGameStatus _gameStatus;
    private Vector3 _playerStartPosition;
    private Quaternion _playerStartRotation;
    private ThirdPersonController _thirdPersonController;
    private CharacterController _characterController;
    
    void Start()
    {
        _gameStatus = ServiceLocator.GetService<IGameStatus>();
        _gameStatus.OnPlayerDead += HandlerPlayerDead;

        _playerStartPosition = transform.position;
        _playerStartRotation = transform.rotation;
        
        _thirdPersonController = GetComponent<ThirdPersonController>();
        _characterController = GetComponent<CharacterController>();
    }

    private void HandlerPlayerDead()
    {
        _thirdPersonController.enabled = false;
        _characterController.enabled = false;
        
        transform.SetPositionAndRotation(_playerStartPosition, _playerStartRotation);
        
        _thirdPersonController.enabled = true;
        _characterController.enabled = true;
    }
}
