using UnityEngine;
using System.Collections;


public class SpawnPoint : WayPoint
{
    protected override Color gizmoColor
    {
        get
        {
            return Color.green;
        }
    }
}
