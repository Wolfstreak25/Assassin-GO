using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Singleton<EnemySpawner>
{
    // EnemyModel modelEnemy;
    EnemyController enemy;
    // List<EnemyController>enemyList = new List<EnemyController>();
    [SerializeField]    private List<EnemyProps> enemyProps = new List<EnemyProps>();
    // private List<EnemyController> enemyControllers = new List<EnemyController>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in enemyProps)
        {
            
            
            switch(item.enemyType)
            {
                case EnemyType.Static:
                    // modelEnemy = new EnemyModel(item);
                    enemy = new StaticEnemyController(item);
                    break;
                case EnemyType.Patrol:
                    // modelEnemy = new EnemyModel(item);
                    enemy = new PatrolEnemyController(item);
                    break;
                case EnemyType.Rotating:
                    // modelEnemy = new EnemyModel(item);
                    enemy = new RotateEnemyController(item);
                    break;
                case EnemyType.Dog:
                    break;
                case EnemyType.Target:
                    break;
            }
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