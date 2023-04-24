using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyController
{
    
    public EnemyModel Model{get; private set;}
    public EnemyView View{get; private set;}
    public bool isDetected{get;private set;}
    private bool isMoving = false;
    private Transform tileTransform;
    
    private Tile tile;
    Sequence sequence;
    public Animator animator{get;private set;}
    
    public EnemyController(EnemyModel Enemymodel, EnemyView _view,Tile _tile)
    {
        tile = _tile;
        tileTransform = _tile.transform;
        tile.isEnemyTile = true;
        isDetected = false;
        this.Model = Enemymodel;
        View = GameObject.Instantiate<EnemyView>(_view, tile.transform.position, Quaternion.identity);
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
    }
    // public void Move(MoveTo direction)
    // {
    //     var next = tile.NextTile(direction);
    //     if(!isMoving && next != null)
    //     {
    //         isMoving = true;
    //         sequence = DOTween.Sequence().Insert(0,View.transform.DOMove(next.transform.position, 1f, false ));
    //         Turn(direction.ToV3());
    //         sequence.OnComplete(() => {
    //                                     EnemyMoved(next);
    //                                     TurnManager.EnemyMoved();
    //                             });
    //     }
    //     return;
    // }
    public void Move(MoveTo direction)
    {
        var next = tile.NextTile(direction);
        if(next == null)
        {
            Turn(Vector3.back);
        }
        next = tile.NextTile(direction);
        if(!isMoving && next != null)
        {
            isMoving = true;
            sequence = DOTween.Sequence().Insert(0,View.transform.DOMove(next.transform.position, 1f, false ));
            Turn(direction.ToV3());
            sequence.OnComplete(() => {
                                        EnemyMoved(next);
                                        TurnManager.EnemyMoved();
                                });
        }
        return;
    }
    public void Turn(Vector3 direction)
    {
        Quaternion rotateEnemy = Quaternion.LookRotation(direction);
        View.transform.rotation = rotateEnemy;
    }
    public void GetDamage(float damage)
    {
            isDetected = true;
            View.DestroyObj();
            // EventManagement.Instance.EnemyDeath();
    }
    
    private void EnemyMoved(Transform next)
    {
        isMoving = false; 
        tile.isEnemyTile = false; 
        tileTransform = next; 
        tile = next.gameObject.GetComponent<Tile>();
        tile.isEnemyTile = true;
    }
}
