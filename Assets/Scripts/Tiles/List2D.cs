using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List2D : MonoBehaviour
{
    private Vector3 vec = new Vector3();
    private MoveTo move = MoveTo.Backward;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(vec);
        vec = MoveTo.Forward.ToV3();
        Debug.Log(vec);
        Debug.Log(move);
        move = vec.ToMoveTo();
        Debug.Log(move);
    }
}
