using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private UtilityType utilityType;
    private UtilityController utility;
    [Header("Neighbour Connections")] //Linked Nodes
    [SerializeField] private List<Tile> neighbourTiles = new List<Tile>();
    [SerializeField] private List<LinkedNodes> linkedNodes = new List<LinkedNodes>();
    [SerializeField] public bool isEndTile;
    [SerializeField] public bool isPlayerTile;
    [SerializeField] public bool isEnemyTile;
    private Transform nextTile;
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
        LinkToNeighbourTiles();
    }

    private void Awake()
    {
        m_coordinate = gameObject.transform.position;
    }
    public Transform NextTile(MoveTo direction)
    {
        foreach (var item in linkedNodes)
        {
            if (item.direction == direction)
            {
                nextTile = item.tile;
                return nextTile;
            }
        }
        return null;

    }
    private void NeighbourTiles()
    {
        var board = FloorBoard.Instance;
        foreach (Vector3 dir in FloorBoard.directions)
        {
            // find a neighboring node at the current direction...
            Tile foundNeighbor = board.Tiles.Find(n => n.Coordinate == Coordinate + dir);

            // if we find a neighbor at this direction, add it to the list
            if (foundNeighbor != null && !neighbourTiles.Contains(foundNeighbor))
            {
                neighbourTiles.Add(foundNeighbor);
            }
        }
    }
    private void LinkToNeighbourTiles()
    {
        for (int i = 0; i < linkedNodes.Count; i++)
        {
            var dir = linkedNodes[i].direction.ToV3();
            var tileLink = neighbourTiles.Find(n => n.Coordinate == Coordinate + dir);
            linkedNodes[i].tile = tileLink.gameObject.transform;
        }
    }
    [System.Serializable]
    public class LinkedNodes
    {
        public MoveTo direction;
        public Transform tile;
    }
    public void UseUtility()
    {
        // Use Utility if any
        if (utilityType != UtilityType.none)
        {

        }
    }
}
