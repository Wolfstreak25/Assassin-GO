using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateEnemyController : EnemyController
{  
    public RotateEnemyController(EnemyProps enemyData):base(enemyData)
    {
        enemyType = EnemyType.Patrol;
    }
    public override void EnemyTurn()
    {
        var nextTile = base.GetNextTile(faceDirection);
        if(nextTile != null && nextTile.PlayerTile)
        {
            base.Move();
        }
        TurnAround();
        TurnManager.EnemyMoved();
    }
    protected override void TurnAround()
    {
        Vector3 angles =  View.transform.eulerAngles;
        View.transform.eulerAngles = angles;
        switch(faceDirection)
        {
            case MoveTo.Forward:
                faceDirection = MoveTo.Backward;
                angles.y = 180;
                break;
            case MoveTo.Backward:
                faceDirection = MoveTo.Forward;
                angles.y = 0;
                break;
            case MoveTo.Left:
                faceDirection = MoveTo.Right;
                angles.y = 90;
                break;
            case MoveTo.Right:
                faceDirection = MoveTo.Left;
                angles.y = -90;
                break;
        }
        View.transform.eulerAngles = angles;
    }
}
