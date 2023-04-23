using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBoard : Singleton<FloorBoard>
{
    private List<Transform> tiles = new List<Transform>();
    public List<Transform> Tiles { get   {return tiles;} }
    void OnEnable()
    {
        for(int i = 0; i<gameObject.transform.childCount; i++)
        {
            tiles.Add(gameObject.transform.GetChild(i).GetComponent<Transform>());
        }
    }
}
