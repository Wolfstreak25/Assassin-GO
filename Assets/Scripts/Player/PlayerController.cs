using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerController
{
    
    public PlayerModel Model{get; private set;}
    public PlayerView View{get; private set;}
    public bool isDetected{get;private set;}
    private bool isMoving;
    private Transform tileTransform;
    private Tile tile;
    Sequence sequence;
    public Animator animator{get;private set;}
    private void OnDisable() 
    {
        //    EventManagement.Instance.OnEnemyDeath -= AmmoDrop;
    }
    public PlayerController(PlayerModel Playermodel, PlayerView _view,Tile _tile)
    {
        tile = _tile;
        tileTransform = _tile.transform;
        tile.isPlayerTile = true;
        isDetected = false;
        this.Model = Playermodel;
        View = GameObject.Instantiate<PlayerView>(_view, tile.transform.position, Quaternion.identity);
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
        PlayerFollow.Instance.GetCamera(View.transform);
    }
    public void Move(MoveTo direction)
    {
        var next = tile.NextTile(direction);
        if(!isMoving && next != null)
        {
            isMoving = true;
            sequence = DOTween.Sequence().Insert(0,View.transform.DOMove(next.transform.position, 1f, false ));
            Turn(direction.ToV3());
            sequence.OnComplete(() => {
                                        isMoving = false; 
                                        tile.isPlayerTile = false; 
                                        tileTransform = next; 
                                        tile = next.gameObject.GetComponent<Tile>();
                                        tile.isPlayerTile = true;
                                });
        }
        return;
    }
    public void Turn(Vector3 direction)
    {
        Quaternion rotatePlayer = Quaternion.LookRotation(direction);
        View.transform.rotation = rotatePlayer;
    }
    public void GetDamage(float damage)
    {
            isDetected = true;
            View.DestroyObj();
            // EventManagement.Instance.PlayerDeath();
    }
    public void AmmoDrop()
    {
        Model.Ammo += 5;
    }
}
