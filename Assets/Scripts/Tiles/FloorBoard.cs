using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBoard : Singleton<FloorBoard>
{
    public static float spacing = 1f;
    private List<Tile> tiles = new List<Tile>();
    public List<Tile> Tiles { get { return tiles; } }
    void OnEnable()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            tiles.Add(gameObject.transform.GetChild(i).GetComponent<Tile>());
        }
    }
    public static readonly Vector3[] directions =
    {
        new Vector3(spacing, 0f, 0f),
        new Vector3(-spacing, 0f, 0f),
        new Vector3(0f, 0f, spacing),
        new Vector3(0f, 0f, -spacing)
    };
}
