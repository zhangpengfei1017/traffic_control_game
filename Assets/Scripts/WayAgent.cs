using UnityEngine;
using System.Collections;

/// <summary>
/// Agent for objects in the way. 
/// Contains information relating to locomotion, and physical calculations
/// Supposed to be the interface between AI and path-finding
/// </summary>
public class WayAgent : MonoBehaviour
{
    /// <summary>
    /// A threshold to check if we arrive the end point
    /// </summary>
    private const float ThresholdDistanceToEnd = 0.2f;

    /// <summary>
    /// The start point of current segment we are in
    /// </summary>
    public WayPoint StartPoint { get; set; }

    /// <summary>
    /// The end point of current segment we are in
    /// </summary>
    public WayPoint EndPoint { get; private set; }

    /// <summary>
    /// Normalized direction vector to the end point, a suggested direction
    /// </summary>
    public Vector3 Direction { get; private set; }

    /// <summary>
    /// Distance to the end point
    /// </summary>
    public float Distance { get; private set; }

    /// <summary>
    /// Update current position within the path of the way
    /// </summary>
    public void UpdateWayPosition()
    {
        if (null == StartPoint) // we are not in any segment of path
        {
            Direction = Vector3.zero;
            Distance = 0;
            return;
        }

        if (null == EndPoint)
        {
            EndPoint = StartPoint.NextWayPoint();

            if (null == EndPoint) // we might arrive the final point
            {
                Direction = Vector3.zero;
                Distance = 0;
                return;
            }
        }

        Vector3 vecToEnd = (EndPoint.transform.position - transform.position);

        if (vecToEnd.magnitude < ThresholdDistanceToEnd)
        {
            StartPoint = EndPoint;
            EndPoint = StartPoint.NextWayPoint();
        }

        Direction = vecToEnd.normalized;
        Distance = vecToEnd.magnitude;
    }
    
    /// <summary>
    /// Move forward in suggested direction
    /// </summary>
    /// <param name="distance">Amount of distance to move</param>
    public void MoveForward(float distance)
    {
        transform.position += Direction * distance;
    }

    /// <summary>
    /// Adjust this vehicle (to which this agent attached) to the current suggested direction.
    /// </summary>
    public void AdjustToCurrentDirection()
    {
        // TODO: a interpolation needed
        if (Direction != Vector3.zero)
            transform.forward = Direction;
    }

    /// <summary>
    /// Get current light type of the traffic light
    /// </summary>
    /// <returns>type of the traffic light that is on</returns>
    public TrafficLight.LightType GetCurrentTrafficLight()
    {
        if (null != EndPoint)
        {
            StopLinePoint p = EndPoint as StopLinePoint;
            if (null != p)
            {
                return p.GetTrafficLightType();
            }
        }
        return TrafficLight.LightType.SteadyGreen;
    }

    /// <summary>
    /// Find 
    /// </summary>
    /// <returns></returns>
    public WayAgent ViechleInFront()
    {
        return null;
    }

    void OnEnable()
    {
        UpdateWayPosition();
    }

    void Start()
    {
        UpdateWayPosition();
    }

    void Update()
    {
        UpdateWayPosition();
    }

}
