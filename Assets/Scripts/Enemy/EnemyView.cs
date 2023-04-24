using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyView : MonoBehaviour
{
    [SerializeField] private Tile EnemyTile;
    private EnemyController Controller;
    private Vector3 movement;
    private float m_timeElapsed = 0f;
    private bool isPlayerTurn = true;
    private void Update()
    {

    }
    private void OnEnable()
    {
        TurnManager.onPlayerMove += PlayerTurn;
    }
    private void OnDisable()
    {
        TurnManager.onPlayerMove -= PlayerTurn;
    }
    public void SetController(EnemyController _controller)
    {
        Controller = _controller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public void GetDamage(float damage)
    {
        Controller.GetDamage(damage);
    }
    public bool isDead()
    {
        return Controller.isDetected;
    }
    private void PlayerTurn()
    {
        isPlayerTurn = false;
        Controller.Move(transform.forward.ToMoveTo());  // ToMoveTo is an Extension function
    }
}