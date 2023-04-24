using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerModel model;
    [SerializeField] private PlayerView view;
    [SerializeField] private Tile spawnTile;
    [SerializeField] private Tile endTile;
    [SerializeField] private EnemyModel modelEnemy;
    [SerializeField] private EnemyView viewEnemy;
    void Start()
    {
        model = new PlayerModel();
        PlayerController controller = new PlayerController(model,view, spawnTile);
        modelEnemy = new EnemyModel();
        EnemyController controllerEnemy = new EnemyController(modelEnemy,viewEnemy, endTile);
    }
}
