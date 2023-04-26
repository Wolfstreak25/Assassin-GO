using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtension
{
    public static Vector3 ToV3(this MoveTo direction)
    {
        var m_vector = new Vector3();
        switch (direction)
        {
            case MoveTo.Forward:
                m_vector = Vector3.forward;
                break;
            case MoveTo.Backward:
                m_vector = Vector3.back;
                break;
            case MoveTo.Left:
                m_vector = Vector3.left;
                break;
            case MoveTo.Right:
                m_vector = Vector3.right;
                break;
        }
        return m_vector;
    }
    public static MoveTo ToMoveTo(this Vector3 direction)
    {
        if (direction == Vector3.forward)
            return MoveTo.Forward;
        if (direction == Vector3.back)
            return MoveTo.Backward;
        if (direction == Vector3.left)
            return MoveTo.Forward;
        if (direction == Vector3.right)
            return MoveTo.Right;
        return MoveTo.none;
    }
    public static Quaternion ToQuat(this MoveTo direction)
    {
        var m_quat = new Quaternion();
        switch(direction)
        {
            case MoveTo.Forward:
                m_quat = Quaternion.LookRotation(Vector3.forward,Vector3.up);
                break;
            case MoveTo.Backward:
                m_quat = Quaternion.LookRotation(Vector3.back,Vector3.up);
                break;
            case MoveTo.Left:
                m_quat = Quaternion.LookRotation(Vector3.left,Vector3.up);
                break;
            case MoveTo.Right:
                m_quat = Quaternion.LookRotation(Vector3.right,Vector3.up);
                break;
        }
        return  m_quat;
    }
}
