using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyController : EnemyController
{
    public StaticEnemyController(EnemyProps enemyData):base(enemyData)
    {
        enemyType = EnemyType.Static;
    }
    public override void EnemyTurn()
    {
        var nextTile = base.GetNextTile(faceDirection);
        if(nextTile != null && nextTile.PlayerTile)
        {
            base.Move();
        }
        TurnManager.EnemyMoved();
    }
}
