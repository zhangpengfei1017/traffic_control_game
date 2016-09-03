using UnityEngine;
using System.Collections;

/// <summary>
/// Overall control
/// </summary>
public class GamePlay : MonoBehaviour
{
    /// <summary>
    /// The main camera in the scene
    /// </summary>
    public Camera m_Camera;

    /// <summary>
    /// LayerMask for objects that response to user clicks
    /// </summary>
    public LayerMask m_LayerMaskForClick;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, m_LayerMaskForClick))
            {
                TrafficLight trafficLight = hitInfo.transform.GetComponent<TrafficLight>();
                if (null != trafficLight)
                {
                    trafficLight.Switch();
                }
            }
        }
    }
}
