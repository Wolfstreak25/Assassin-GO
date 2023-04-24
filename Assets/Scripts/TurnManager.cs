using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class TurnManager
{
    public static event Action onPlayerMove;
    public static event Action onEnemyMove;
    public static void PlayerMoved()
    {
        onPlayerMove?.Invoke();
    }
    public static void EnemyMoved()
    {
        onEnemyMove?.Invoke();
    }
}
