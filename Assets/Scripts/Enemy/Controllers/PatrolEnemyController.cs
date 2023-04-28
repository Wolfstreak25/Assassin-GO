using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemyController : EnemyController
{
    protected Tile nextTile;
    public PatrolEnemyController(EnemyProps enemyData):base(enemyData)
    {
        enemyType = EnemyType.Patrol;
    }
    private void OnEnable() 
    {
        TurnManager.onPlayerMove += EnemyTurn;
    }
    private void OnDisable() 
    {
        TurnManager.onPlayerMove -= EnemyTurn;
    }
    public override void EnemyTurn()
    {
        nextTile = base.GetNextTile(faceDirection);
        if(nextTile != null && nextTile.PlayerTile)
        {
            base.Move();
        }
        Move();
    }
    protected override void Move()
    {
        if(!isMoving && nextTile != null)
        {
            isMoving = true;
            View.transform.position = nextTile.Coordinate;
            // Turn(faceDirection.ToV3());
            EnemyMoved(nextTile);
            TurnManager.EnemyMoved();
        }
        GetNextTile(faceDirection);
        return;
    }
    protected override Tile GetNextTile(MoveTo direction)
    {
        Tile next = tile.NextTile(faceDirection);
        if(next == null)
        {
            TurnAround();
            next = tile.NextTile(faceDirection);
        }
        return next;
    }
}
