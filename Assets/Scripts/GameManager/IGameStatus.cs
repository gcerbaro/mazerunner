using System;

public interface IGameStatus
{
    // event Action OnGameOver;
    // event Action OnStartGame;
    // event Action OnEndGame;
    // event Action OnPauseGame;
    // event Action OnWinGame;
    event Action OnPlayerDead;

    void InvokePlayerDeadEvent();
}