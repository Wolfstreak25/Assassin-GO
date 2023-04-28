using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private PlayerModel model;
    [SerializeField] private PlayerView view;
    [SerializeField] private Tile playerSpawnTile;
    void Start()
    {
        model = new PlayerModel();
        PlayerController controller = new PlayerController(model,view, playerSpawnTile);
    }
}
