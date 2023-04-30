using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerController
{
    public PlayerModel Model { get; private set; }
    public PlayerView View { get; private set; }
    public bool isDetected { get; private set; }
    private bool isMoving = false;
    private Tile tile;
    [SerializeField] private float moveDuration = 0.5f;
    public Animator animator { get; private set; }

    public PlayerController(PlayerModel Playermodel, PlayerView _view, Tile _tile)
    {
        tile = _tile;
        tile.SetPlayerTile(this);
        isDetected = false;
        this.Model = Playermodel;
        View = GameObject.Instantiate<PlayerView>(_view, tile.transform.position, Quaternion.identity);
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
        // PlayerFollow.Instance.GetCamera(View.transform);
    }
    public void Move(MoveTo direction)
    {
        var next = tile.NextTile(direction);
        if (!isMoving && next != null)
        {
            View.PlayerAnimator.SetTrigger("Jump");
            isMoving = true;
            var sequence = DOTween.Sequence();
            sequence.Insert(0, View.transform.DOMove(next.Coordinate, moveDuration));
            Turn(direction.ToV3());
            sequence.OnComplete(() => PlayerMoved(next));
            // sequence.OnComplete(()=>TurnManager.PlayerMoved());
            // View.transform.position = next.Coordinate;
            // UseUtility();            
        }
        return;
    }
    public void Turn(Vector3 direction)
    {
        Quaternion rotatePlayer = Quaternion.LookRotation(direction);
        View.transform.rotation = rotatePlayer;
    }
    public void GetDamage()
    {
        UIManager.Instance.PlayerDeathUI();
        isDetected = true;
        View.DestroyObj();
        // EventManagement.Instance.PlayerDeath();
    }

    private void UseUtility()
    {
        tile.UseUtility();
    }
    private void PlayerMoved(Tile next)
    {
        isMoving = false;
        View.PlayerAnimator.SetTrigger("Idle");
        tile.UnsetPlayerTile();
        tile = next;
        tile.SetPlayerTile(this);
        TurnManager.PlayerMoved();
    }
}
