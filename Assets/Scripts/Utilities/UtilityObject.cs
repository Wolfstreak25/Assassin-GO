using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Utility Object", menuName = "Objects/New Utility Object")]
public class UtilityObject : ScriptableObject
{
    public UtilityView view;
    public UtilityType type;
}
