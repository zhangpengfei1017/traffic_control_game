using UnityEngine;
using System.Collections;

/// <summary>
/// AI for debug, DO NOT use
/// </summary>
public class CarAITestJustGo : MonoBehaviour
{
    public float speed = 1.0f;

    private WayAgent agent;

    void Awake()
    {
        agent = GetComponent<WayAgent>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = speed * Time.deltaTime;
        agent.MoveForward(dist);
        agent.AdjustToCurrentDirection();
    }
}
