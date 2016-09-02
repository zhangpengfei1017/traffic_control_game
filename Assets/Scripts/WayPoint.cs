using UnityEngine;
using System.Collections;


public class WayPoint : MonoBehaviour
{
    public WayPoint[] m_Outbounds;

    protected Color m_gizmosColor = Color.blue;

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = m_gizmosColor;
        Gizmos.DrawSphere(transform.position, 0.5f);

        if (null == m_Outbounds)
        {
            return;
        }

        Gizmos.color = Color.yellow;
        for (int i = 0; i < m_Outbounds.Length; i++)
        {
            Gizmos.DrawLine(transform.position, m_Outbounds[i].transform.position);
        }
    }
}
