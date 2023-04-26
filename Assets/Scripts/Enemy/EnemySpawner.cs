using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    [SerializeField]    private List<EnemyProps> enemyProps = new List<EnemyProps>();
    // private List<EnemyController> enemyControllers = new List<EnemyController>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in enemyProps)
        {
            
            EnemyModel modelEnemy = new EnemyModel(item);
            EnemyController enemy = new EnemyController(modelEnemy,item.enemyPrefab, item.spawnTile,item.faceDirection.ToQuat());
            // switch(item.enemyType)
            // {
            //     case EnemyType.Static:
            //         modelEnemy = new EnemyModel(item);
            //         enemy = new EnemyController(modelEnemy,item.enemyPrefab, item.spawnTile,item.faceDirection.ToQuat());
            //         break;
            //     case EnemyType.Patrol:
            //         modelEnemy = new EnemyModel(item);
            //         enemy = new EnemyController(modelEnemy,item.enemyPrefab, item.spawnTile,item.faceDirection.ToQuat());
            //         break;
            //     case EnemyType.Rotating:
            //         modelEnemy = new EnemyModel(item);
            //         enemy = new EnemyController(modelEnemy,item.enemyPrefab, item.spawnTile,item.faceDirection.ToQuat());
            //         break;
            //     case EnemyType.Dog:
            //         break;
            //     case EnemyType.Target:
            //         break;
            // }
        }
    }
}
[System.Serializable]
public struct EnemyProps
{
    public EnemyType enemyType;
    public MoveTo faceDirection;
    public EnemyView enemyPrefab;
    public Tile spawnTile;
}