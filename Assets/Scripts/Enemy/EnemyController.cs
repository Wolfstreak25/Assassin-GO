susing UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class EnemyController
{
    public EnemyType enemyType;
    public EnemyView View { get; private set; }
    public bool isDetected { get; private set; }
    protected float moveDelay = 0.5f;
    protected float rotateDelay = 0.25f;
    protected bool isMoving = false;
    protected Tile tile;
    protected MoveTo faceDirection;
    // protected Quaternion spawnRotation;
    public EnemyController(EnemyProps enemyData)
    {
        // spawnRotation = enemyData.faceDirection.ToQuat();
        // Debug.Log(spawnRotation.eulerAngles);
        tile = enemyData.spawnTile;
        faceDirection = enemyData.faceDirection;
        tile.SetEnemyTile(this);
        View = GameObject.Instantiate<EnemyView>(enemyData.enemyPrefab, tile.Coordinate, Turn(faceDirection));
        // Turn(faceDirection);
        this.View.SetController(this);
    }
    protected Quaternion Turn(MoveTo direction)
    {
        float y = 0f;
        switch (direction)
        {
            case MoveTo.Forward:
                y = 0f;
                break;
            case MoveTo.Backward:
                y = 180f;
                break;
            case MoveTo.Left:
                y = -90f;
                break;
            case MoveTo.Right:
                y = 90f;
                break;
        }
        return Quaternion.Euler(0f, y, 0f);
    }
    protected virtual void Move()
    {
        var next = GetNextTile(faceDirection);
        isMoving = true;
        var sequence = DOTween.Sequence();
        sequence.Insert(0, View.transform.DOMove(next.Coordinate, moveDelay));
        sequence.OnComplete(() => EnemyMoved(next));
        // View.transform.position = next.Coordinate;
        // EnemyMoved(next);
    }
    public virtual void EnemyTurn()
    {

    }
    protected virtual void NoMove()
    {
        return;
    }
    protected virtual void TurnAround()
    {
        Vector3 angles = View.transform.eulerAngles;
        View.transform.eulerAngles = angles;
        switch (faceDirection)
        {
            case MoveTo.Forward:
                faceDirection = MoveTo.Backward;
                angles.y = 180;
                break;
            case MoveTo.Backward:
                faceDirection = MoveTo.Forward;
                angles.y = 0;
                break;
            case MoveTo.Left:
                faceDirection = MoveTo.Right;
                angles.y = 90;
                break;
            case MoveTo.Right:
                faceDirection = MoveTo.Left;
                angles.y = -90;
                break;
        }
        var sequence = DOTween.Sequence();
        sequence.Insert(0, View.transform.DORotate(angles, rotateDelay));
        // sequence.OnComplete(()=>EnemyMoved(nextTile));
        // View.transform.eulerAngles = angles;
    }
    public virtual void GetDamage()
    {
        Debug.Log("Called damage enemy");
        isDetected = true;
        View.DestroyObj();
        // EventManagement.Instance.EnemyDeath();
    }

    protected virtual void EnemyMoved(Tile next)
    {
        isMoving = false;
        tile.UnsetEnemyTile(this);
        tile = next;
        tile.SetEnemyTile(this);
    }
    protected virtual Tile GetNextTile(MoveTo direction)
    {
        Tile next = tile.NextTile(faceDirection);
        return next;
    }
}