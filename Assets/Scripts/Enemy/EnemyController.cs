using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyController
{

    public EnemyModel Model { get; private set; }
    public EnemyView View { get; private set; }
    public bool isDetected { get; private set; }
    private bool isMoving = false;
    private Transform tileTransform;

    private Tile tile;
    Sequence sequence;
    public Animator animator { get; private set; }

    public EnemyController(EnemyModel Enemymodel, EnemyView _view, Tile _tile)
    {
        tile = _tile;
        tileTransform = _tile.transform;
        tile.SetEnemyTile(this);
        isDetected = false;
        this.Model = Enemymodel;
        View = GameObject.Instantiate<EnemyView>(_view, tile.transform.position, Quaternion.identity);
        this.View.SetController(this);
        this.Model.SetController(this);
        animator = View.GetComponent<Animator>();
    }
    public void Move(MoveTo direction)
    {
        var next = tile.NextTile(direction);
        if (next == null)
        {
            Debug.Log("called");
            TurnAround();
        }
        if (!isMoving && next != null)
        {
            isMoving = true;
            sequence = DOTween.Sequence().Insert(0, View.transform.DOMove(next.transform.position, 1f, false));
            Turn(direction.ToV3());
            sequence.OnComplete(() =>
            {
                EnemyMoved(next);
                TurnManager.EnemyMoved();
            });
        }
        return;
    }
    private void Turn(Vector3 direction)
    {
        Quaternion rotateEnemy = Quaternion.LookRotation(direction);
        View.transform.rotation = rotateEnemy;
    }
    private void TurnAround()
    {
        Vector3 angles = View.transform.eulerAngles;
        angles.y += 180;
        View.transform.eulerAngles = angles;
        var direction = View.transform.forward;
        Move(direction.ToMoveTo());
    }
    public void GetDamage()
    {
        Debug.Log("Called damage enemy");
        isDetected = true;
        View.DestroyObj();
        // EventManagement.Instance.EnemyDeath();
    }

    private void EnemyMoved(Transform next)
    {
        isMoving = false;
        tile.UnsetEnemyTile();
        tileTransform = next;
        tile = next.gameObject.GetComponent<Tile>();
        tile.SetEnemyTile(this);
    }
}
