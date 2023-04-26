// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class StaticEnemyController : EnemyController
// {
//     public StaticEnemyController(EnemyModel enemymodel, EnemyView _view,Tile _tile,Quaternion _rotation):base(enemymodel,_view,_tile,_rotation)
//     {
//         enemyType = EnemyType.Static;
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
// }
