using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        Debug.Log("nexttile1" + nextTile);
        if(nextTile != null && nextTile.PlayerTile)
        {
            base.Move();
        }
        else if(nextTile == null)
        {
            TurnAround();
        }
        Move();
        TurnManager.EnemyMoved();
    }
    protected override void Move()
    {
        Debug.Log("called");
        // nextTile = base.GetNextTile(faceDirection);
        if(!isMoving && nextTile != null)
        {
            isMoving = true;
            var sequence = DOTween.Sequence();
            sequence.Insert(0,View.transform.DOMove(nextTile.Coordinate, moveDelay));
            sequence.OnComplete(()=>EnemyMoved(nextTile));
            Debug.Log("called");
            // Turn(faceDirection.ToV3());
            // EnemyMoved(nextTile);
        }
        nextTile = GetNextTile(faceDirection);
        Debug.Log("nexttile2" + nextTile);
        return;
    }
    protected override Tile GetNextTile(MoveTo direction)
    {
        Tile next = tile.NextTile(faceDirection);
        Debug.Log("next0" + next);
        if(next == null)
        {
            Debug.Log("next1" + next);
            TurnAround();
        }
        return next;
    }
}
