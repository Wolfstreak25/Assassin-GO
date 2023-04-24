
using UnityEngine;

public class PlayerModel
{
    public float TurnSpeed;
    private float health;
    private PlayerController PlayerController;
    // private PlayerObject PlayerObject;
    
    // public PlayerModel(PlayerObject _PlayerObject)
    // {
    //     this.PlayerObject = _PlayerObject;
    //     TurnSpeed = PlayerObject.TurnSpeed;
    //     health = PlayerObject.Health;
    // }

       public void SetController(PlayerController Playercontroller)
    {
        PlayerController = Playercontroller;
    }
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            health =  (int)value;
        }
    }
    public int Ammo{get;set;}
   
}
