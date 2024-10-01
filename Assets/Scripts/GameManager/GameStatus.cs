using System;

public class GameStatus : IGameStatus
{
    public event Action OnPlayerDead;
    
    public void InvokePlayerDeadEvent()
    {
        OnPlayerDead?.Invoke();
    }
}