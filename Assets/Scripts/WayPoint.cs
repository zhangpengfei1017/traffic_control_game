using UnityEngine;
using System.Collections;

/// <summary>
/// Base class of all way points
/// </summary>
public class WayPoint : MonoBehaviour
{
    /// <summary>
    /// List of all way points that the current one connected to. The 0th in the array should be the default one.
    /// </summary>
    [SerializeField]
    private WayPoint[] m_Outbounds;

    /// <summary>
    /// Find out a way point as the next point in the path
    /// </summary>
    /// <returns>the way point found</returns>
    public virtual WayPoint NextWayPoint()
    {
        if (null != m_Outbounds && m_Outbounds.Length > 0)
        {
            return m_Outbounds[0];
        }

        return null;
    }

    protected virtual Color gizmoColor
    {
        get
        {
            return Color.blue;
        }
    }

    void OnDrawGizmos()
    {
        DrawGizmos(0.5f, Color.yellow);
    }

    void OnDrawGizmosSelected()
    {
        DrawGizmos(1.0f, Color.white);
    }

    void DrawGizmos(float radius, Color lineColor)
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(transform.position, radius);

        if (null == m_Outbounds)
        {
            return;
        }

        Gizmos.color = lineColor;
        for (int i = 0; i < m_Outbounds.Length; i++)
        {
            Gizmos.DrawLine(transform.position, m_Outbounds[i].transform.position);
        }
    }
}
