
using UnityEngine;

public class EnemyModel
{
    public float TurnSpeed;
    private float health;
    private EnemyController EnemyController;
    // private EnemyObject EnemyObject;

    // public EnemyModel(EnemyObject _EnemyObject)
    // {
    //     this.EnemyObject = _EnemyObject;
    //     TurnSpeed = EnemyObject.TurnSpeed;
    //     health = EnemyObject.Health;
    // }

    public void SetController(EnemyController Enemycontroller)
    {
        EnemyController = Enemycontroller;
    }
}
