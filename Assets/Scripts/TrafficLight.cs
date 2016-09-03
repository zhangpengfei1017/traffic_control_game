using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// Logic and visual management for a single traffic light
/// </summary>
public class TrafficLight : MonoBehaviour
{
    public enum LightType
    {
        SteadyRed,
        SteadyYellow,
        SteadyGreen
    }

    [Serializable]
    private class TrafficLightConfig
    {
        public LightType LightType;
        public Material MaterialOn;
        public Material MaterialOff;
        public Renderer Renderer;
    }

    /// <summary>
    /// if the light transit from yellow to red automatically
    /// </summary>
    [SerializeField]
    private bool m_IsAutoTransitYToR = true;

    /// <summary>
    /// seconds for yellow light stay, in automatic mode
    /// </summary>
    [SerializeField]
    private float m_AutoTransitInterval = 5.0f;

    [SerializeField]
    private LightType m_InitialLight;

    [SerializeField]
    private TrafficLightConfig[] m_Config;

    private Dictionary<LightType, TrafficLightConfig> m_ConfigDict;
    private LightType m_CurrentLight;

    /// <summary>
    /// type of current light
    /// </summary>
    public LightType CurrentLight
    {
        get
        {
            return m_CurrentLight;
        }
        set
        {
            for (int i = 0; i < m_Config.Length; i++)
            {
                m_Config[i].Renderer.sharedMaterial = (m_Config[i].LightType == value ? m_Config[i].MaterialOn : m_Config[i].MaterialOff);
            }
            m_CurrentLight = value;
        }
    }

    /// <summary>
    /// Switch traffic light
    /// </summary>
    public void Switch()
    {
        switch (CurrentLight)
        {
            case LightType.SteadyRed:
                CurrentLight = LightType.SteadyGreen;
                break;
            case LightType.SteadyYellow:
                if (!m_IsAutoTransitYToR)
                {
                    CurrentLight = LightType.SteadyRed;
                }
                break;
            case LightType.SteadyGreen:
                CurrentLight = LightType.SteadyYellow;
                break;
        }
    }

    void OnEnable()
    {
        m_ConfigDict = new Dictionary<LightType, TrafficLightConfig>();
        for (int i = 0; i < m_Config.Length; i++)
        {
            if (m_ConfigDict.ContainsKey(m_Config[i].LightType))
            {
                throw new Exception("Invalid Configuration!");
            }
            m_ConfigDict.Add(m_Config[i].LightType, m_Config[i]);
        }
    }

    void Start()
    {
        CurrentLight = m_InitialLight;
    }

    float m_TransitTimer;
    void Update()
    {
        if (m_IsAutoTransitYToR && LightType.SteadyYellow == CurrentLight)
        {
            m_TransitTimer += Time.deltaTime;
            if (m_TransitTimer >= m_AutoTransitInterval)
            {
                m_TransitTimer = 0;
                CurrentLight = LightType.SteadyRed;
            }
        }
    }
}
