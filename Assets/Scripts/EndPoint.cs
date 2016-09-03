using UnityEngine;
using System.Collections;

public class EndPoint : WayPoint
{
    protected override Color gizmoColor
    {
        get
        {
            return Color.gray;
        }
    }
}
