 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyView : MonoBehaviour
{
    [SerializeField]    private Tile EnemyTile;
    private EnemyController Controller;
    private Vector3 movement;
    // private float m_timeElapsed = 0f;
    private bool isPlayerTurn = true;
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
        isPlayerTurn = false;
        switch(Controller.Model.enemyType)
        {
            case EnemyType.Static:
            Debug.Log("static enemy turn");
                Controller.NoMove();
                break;
            case EnemyType.Patrol:
            Debug.Log("patrol enemy turn");
                Controller.Move(transform.forward.ToMoveTo());
                break;
            case EnemyType.Rotating:
            Debug.Log("rotating enemy turn");
                Controller.TurnAround();
                break;
        }
    }
}