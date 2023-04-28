using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyView : MonoBehaviour
{
    [SerializeField] private Tile EnemyTile;
    private EnemyController Controller;
    private void OnEnable()
    {
        TurnManager.onPlayerMove += EnemyTurn;
    }
    private void OnDisable()
    {
        TurnManager.onPlayerMove -= EnemyTurn;
    }
    public void SetController(EnemyController _controller)
    {
        Controller = _controller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public bool isDead()
    {
        return Controller.isDetected;
    }
    private void EnemyTurn()
    {
        Controller.EnemyTurn();
    }
}