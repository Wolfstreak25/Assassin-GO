using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]    private UtilityType utilityType;
    private UtilityController utility;
    [Header("Neighbour Connections")] //Linked Nodes
    // [SerializeField]    private Tile leftTile;
    // [SerializeField]    private Tile rightTile;
    // [SerializeField]    private Tile forwardTile;
    // [SerializeField]    private Tile backTile;
    [SerializeField]    public bool isPlayerTile;
    [SerializeField]    private bool isEnemyTile;
    private Transform nextTile;
    // [SerializeField] private List<NeighbourTiles> neighbourTiles;
    void Start()
    {
        if(utilityType != UtilityType.none)
        {
            utility = UtilityService.Instance.GetUtility(utilityType);
        }
    }

   public Transform NextTile (MoveTo direction)
   {
        switch(direction)
        {
            case MoveTo.Forward:
                nextTile = NeighbourTiles(Vector3.forward);
                break;
            case MoveTo.Backward:
                nextTile = NeighbourTiles(Vector3.back);;
                break;
            case MoveTo.Left:
                nextTile = NeighbourTiles(Vector3.left);;
                break;
            case MoveTo.Right:
                nextTile = NeighbourTiles(Vector3.right);;
                break;
        }
        return nextTile;
   }
   private Transform NeighbourTiles(Vector3 direction)
   {
        var nTile = FloorBoard.Instance.Tiles.Find(n => n.transform.position == transform.position + direction);
        return nTile;
   }
}


// [System.Serializable]
// struct NeighbourTiles
// {
//     public MoveTo tileDirection;
//     private Tile m_tile;
//     public Tile tile
//     {
//         get
//         {
//             m_tile = FloorBoard.Instance.Tiles.Find(n => n.transform.position == transform.position + m_tile.direction);
//             return m_tile;
//         }
//     }
//     private Vector3 dir;
//     public Vector3 direction
//     {
//         get
//         {
//             switch(tileDirection)
//             {
//                 case MoveTo.Forward:
//                     dir = Vector3.forward;
//                     break;
//                 case MoveTo.Backward:
//                     dir = Vector3.back;
//                     break;
//                 case MoveTo.Left:
//                     dir = Vector3.left;
//                     break;
//                 case MoveTo.Right:
//                     dir = Vector3.right;
//                     break;
//             }
//             return dir;
//         }
//     }
// } 