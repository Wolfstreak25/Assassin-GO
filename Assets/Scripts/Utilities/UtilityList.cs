using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "Utility List", menuName = "Objects/New Utility Object List")]
public class UtilityList : ScriptableObject
{
    public ObjectUtil[] Utility;
}
[System.Serializable]
public struct ObjectUtil
{
    public UtilityType type;
    public UtilityObject obj;
}