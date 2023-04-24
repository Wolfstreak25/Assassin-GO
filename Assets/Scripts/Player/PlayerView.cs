using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerView : MonoBehaviour
{
    [SerializeField]    private Tile playerTile;
    private PlayerController Controller;
    private Vector3 movement;
    private float m_timeElapsed = 0f;
    private void Update() 
    {
        m_timeElapsed += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.W))
            Controller.Move(MoveTo.Forward);
        if(Input.GetKeyDown(KeyCode.A))
            Controller.Move(MoveTo.Left);
        if(Input.GetKeyDown(KeyCode.S))
            Controller.Move(MoveTo.Backward);
        if(Input.GetKeyDown(KeyCode.D))
            Controller.Move(MoveTo.Right);
    }
    public void SetController(PlayerController _controller)
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
}