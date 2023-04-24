using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private PlayerModel model;
    [SerializeField] private PlayerView view;
    [SerializeField] private Tile spawnTile;
    void Start()
    {
        model = new PlayerModel();
        PlayerController controller = new PlayerController(model,view, spawnTile);
    }
}
