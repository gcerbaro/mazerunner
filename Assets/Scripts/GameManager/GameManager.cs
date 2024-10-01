using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.RegisterService<IGameStatus>(new GameStatus());
    }
}