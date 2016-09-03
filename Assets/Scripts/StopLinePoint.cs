using UnityEngine;
using System.Collections;

public class StopLinePoint : WayPoint
{
    protected override Color gizmoColor
    {
        get
        {
            return Color.red;
        }
    }

    /// <summary>
    /// The traffic light to which this point is subject
    /// </summary>
    [SerializeField]
    private TrafficLight m_TrafficLight;


}
