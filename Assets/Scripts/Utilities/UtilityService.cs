using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityService : Singleton<UtilityService>
{
    [SerializeField]    private UtilityList utilityList;
    public UtilityController GetUtility(UtilityType utilityType)
    {
        UtilityModel model = new UtilityModel();
        UtilityController controller = new UtilityController();
        return controller;
    }
    private UtilityObject GetObject(UtilityType utilityType)
    {
        foreach (var utility in utilityList.Utility)
        {
            if(utility.type == utilityType)
            {
                return utility.obj;
            }
        }
        return null;
    }
}
