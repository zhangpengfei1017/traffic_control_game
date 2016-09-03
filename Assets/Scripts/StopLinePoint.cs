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

    /// <summary>
    /// Get current light type of the traffic light
    /// </summary>
    /// <returns>type of the traffic light that is on</returns>
    public TrafficLight.LightType GetTrafficLightType()
    {
        return m_TrafficLight.CurrentLight;
    }
}
