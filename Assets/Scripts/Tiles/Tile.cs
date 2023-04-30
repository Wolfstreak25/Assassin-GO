using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Tile Atributes
    [Header("Tile States")]
    [SerializeField] private bool isEndTile;
    [SerializeField] private bool isPlayerTile;
    [SerializeField] private bool isEnemyTile;
    [SerializeField] private float nodeSpawnDelay = 0.5f;
    public bool EndTile { get { return isEndTile; } }
    public bool PlayerTile { get { return isPlayerTile; } }
    // public bool PlayerTile {   get{return isPlayerTile;}   }
    [Header("Gameobject Reference")]
    [SerializeField] private Links linkPrefab;
    [SerializeField] private GameObject dot;
    [SerializeField] private GameObject endDot;
    [Header("Tile Utility")]
    [SerializeField] private UtilityType utilityType;
    private UtilityController utility;
    [Header("Neighbour Connections")] //Linked Nodes
    [SerializeField] private List<LinkedNodes> linkedNodes = new List<LinkedNodes>();
    [SerializeField] private List<Tile> neighbourTiles = new List<Tile>();
    public List<Tile> linkedTiles = new List<Tile>();
    // public List<Tile> LinkedTiles { get{return linkedTiles;}}

    private List<EnemyController> enemy = new List<EnemyController>();
    // private EnemyController enemy;
    private PlayerController player;
    // private Transform nextTile;
    private Vector3 m_coordinate = new Vector3();
    public Vector3 Coordinate { get { return m_coordinate; } }
    // [SerializeField] private List<NeighbourTiles> neighbourTiles;
    void Start()
    {

        if (utilityType != UtilityType.none)
        {
            utility = UtilityService.Instance.GetUtility(utilityType);
        }
        NeighbourTiles();
    }

    private void OnEnable()
    {
        m_coordinate = gameObject.transform.position;

    }
    public IEnumerator InitializeTile()
    {
        yield return new WaitForSeconds(nodeSpawnDelay);
        if (isEndTile)
        {
            GameObject.Instantiate(endDot, Coordinate, Quaternion.identity);
        }
        else
        {
            GameObject.Instantiate(dot, Coordinate, Quaternion.identity).transform.SetParent(this.transform);
        }
        LinkToNeighbourTiles();
    }
    private void NeighbourTiles()
    {
        var board = FloorBoard.Instance;
        foreach (Vector3 dir in FloorBoard.directions)
        {
            Tile foundNeighbor = board.Tiles.Find(n => n.Coordinate == Coordinate + dir);
            if (foundNeighbor != null && !neighbourTiles.Contains(foundNeighbor))
            {
                neighbourTiles.Add(foundNeighbor);
            }
        }
    }
    private void LinkToNeighbourTiles()
    {
        foreach (var item in linkedNodes)
        // for (int i = 0; i < linkedNodes.Count; i++)
        {
            // var item = linkedNodes[i];
            var dir = item.direction.ToV3();
            var tileLink = neighbourTiles.Find(n => n.Coordinate == Coordinate + FloorBoard.spacing * dir);
            if (tileLink != null && item.tile != tileLink)
            {
                item.tile = tileLink;
                if (!linkedTiles.Contains(tileLink))
                {
                    linkedTiles.Add(tileLink);
                    SpawnLinks(tileLink);
                }
                StartCoroutine(tileLink.InitializeTile());
            }
        }
    }
    private void SpawnLinks(Tile targetNode)
    {
        if (linkPrefab != null)
        {
            // instantiate our prefab and parent to this Node
            Links linkInstance = GameObject.Instantiate<Links>(linkPrefab, Coordinate, Quaternion.identity);
            linkInstance.transform.SetParent(this.transform);

            // draw the link
            Links link = linkInstance;
            if (link != null)
            {
                link.DrawLink(Coordinate, targetNode.Coordinate);
            }
            // track what Nodes have been linked to other Nodes
            if (!targetNode.linkedTiles.Contains(this))
            {
                targetNode.linkedTiles.Add(this);
            }
        }
    }
    public void UseUtility()
    {
        // Use Utility if any
        if (utilityType != UtilityType.none)
        {

        }
    }
    public Tile NextTile(MoveTo direction)
    {
        foreach (var item in linkedNodes)
        {
            if (item.direction == direction)
            {
                return item.tile;
            }
        }
        return null;
    }
    public void SetPlayerTile(PlayerController _player)
    {
        if (isEnemyTile)
        {
            foreach (var item in enemy)
            {
                item.GetDamage();
            }
            UnsetEnemyTile();
        }
        if (isEndTile)
        {
            UIManager.Instance.LevelEndUI();
        }
        player = _player;
        isPlayerTile = true;
    }
    public void UnsetPlayerTile()
    {
        player = null;
        isPlayerTile = false;
    }
    public void SetEnemyTile(EnemyController _enemy)
    {
        if (isPlayerTile)
        {
            player.GetDamage();
            UnsetPlayerTile();
        }
        enemy.Add(_enemy);
        isEnemyTile = true;
    }
    private void UnsetEnemyTile()
    {
        enemy.Clear();
        isEnemyTile = false;
    }
    public void UnsetEnemyTile(EnemyController _enemy)
    {
        enemy.Remove(_enemy);
        if (enemy.Count == 0)
            isEnemyTile = false;
    }
}

[System.Serializable]
public class LinkedNodes
{
    public MoveTo direction;
    public Tile tile;
}