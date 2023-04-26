// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using DG.Tweening;

// public class PatrolEnemyController : EnemyController
// {
//     public PatrolEnemyController(EnemyModel enemymodel, EnemyView _view,Tile _tile,Quaternion _rotation):base(enemymodel,_view,_tile,_rotation)
//     {
//         enemyType = EnemyType.Patrol;
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
//         Move(View.transform.forward.ToMoveTo());
//     }
//     private void Move(MoveTo direction)
//     {
//         var next = tile.NextTile(direction);
//         if(next == null)
//         {
//             Debug.Log("called");
//             TurnAround();
//         }
//         if(!isMoving && next != null)
//         {
//             isMoving = true;
//             Sequence sequence = DOTween.Sequence().Insert(0,View.transform.DOMove(next.transform.position, 1f, false ));
//             Turn(direction.ToV3());
//             sequence.OnComplete(() => {
//                                         EnemyMoved(next);
//                                         TurnManager.EnemyMoved();
//                                 });
//         }
//         return;
//     }
//     protected override void TurnAround()
//     {
//         Vector3 angles =  View.transform.eulerAngles;
//         angles.y += 180;
//         View.transform.eulerAngles = angles;
//         var direction = View.transform.forward;
//         Move(direction.ToMoveTo());
//     }
// }
