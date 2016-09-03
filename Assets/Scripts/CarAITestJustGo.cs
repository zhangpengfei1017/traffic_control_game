using UnityEngine;
using System.Collections;

/// <summary>
/// AI for debug, DO NOT use
/// </summary>
public class CarAITestJustGo : MonoBehaviour
{
    public float speed;

    public float acceleration = 1000.0f;

    private WayAgent agent;

    public float iniTime;

    void Awake()
    {
        agent = GetComponent<WayAgent>();

        iniTime = Time.realtimeSinceStartup;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.Distance > 1 || agent.GetCurrentTrafficLight() == TrafficLight.LightType.SteadyGreen)
        {
            if (speed <= 10.0f)
            {
                speed = acceleration * (Time.realtimeSinceStartup - iniTime);
            }

            print("speed: " + speed);

            float dist = speed * Time.deltaTime;
            agent.MoveForward(dist);
            agent.AdjustToCurrentDirection();
        }
    }
}
