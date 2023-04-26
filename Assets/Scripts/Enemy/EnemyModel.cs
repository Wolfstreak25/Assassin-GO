
using UnityEngine;

public class EnemyModel
{
    private EnemyController EnemyController;
    // private EnemyObject EnemyObject;
    public EnemyType enemyType{get;private set;}
    public EnemyModel(EnemyProps enemy)
    {
        enemyType = enemy.enemyType;
    }

    public void SetController(EnemyController Enemycontroller)
    {
        EnemyController = Enemycontroller;
    }
}
