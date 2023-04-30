using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerView : MonoBehaviour
{
    [SerializeField] private Tile playerTile;
    [SerializeField] private Animator playerAnimator;
    public Animator PlayerAnimator { get { return playerAnimator; } }
    private PlayerController Controller;
    private Vector3 movement;
    private float m_timeElapsed = 0f;
    private bool isEnemyTurn = false;
    private void OnEnable()
    {
        TurnManager.onEnemyMove += EnemyTurn;
    }
    private void OnDisable()
    {
        TurnManager.onEnemyMove -= EnemyTurn;
    }
    private void Update()
    {
        m_timeElapsed += Time.deltaTime;
        if (!isEnemyTurn)
        {
            if (Input.GetKeyDown(KeyCode.W))
                Controller.Move(MoveTo.Forward);
            if (Input.GetKeyDown(KeyCode.A))
                Controller.Move(MoveTo.Left);
            if (Input.GetKeyDown(KeyCode.S))
                Controller.Move(MoveTo.Backward);
            if (Input.GetKeyDown(KeyCode.D))
                Controller.Move(MoveTo.Right);
        }
    }
    public void SetController(PlayerController _controller)
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
        isEnemyTurn = false;
    }
}