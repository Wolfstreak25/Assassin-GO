// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;
// public class RotateEnemyController : EnemyController
// {
//     public RotateEnemyController(EnemyModel enemymodel, EnemyView _view,Tile _tile,Quaternion _rotation):base(enemymodel,_view,_tile,_rotation)
//     {
//         enemyType = EnemyType.Rotating;
//     }  
//     private void OnEnable() 
//     {
//         TurnManager.onPlayerMove += EnemyTurn;
//     }
//     private void OnDisable() 
//     {
//         TurnManager.onPlayerMove -= EnemyTurn;
//     }
//     public override void EnemyTurn()
//     {
//         TurnManager.EnemyMoved();
//     }
//     protected override void TurnAround()
//     {
//         var sequence = DOTween.Sequence();
//         Vector3 angles =  View.transform.eulerAngles;
//         angles.y += 180;
//         sequence.Insert(0,View.transform.DORotate(angles, 0.5f,RotateMode.Fast));
//         // View.transform.eulerAngles = angles;
//         sequence.OnComplete(() => {TurnManager.EnemyMoved();});
//     }
// }
