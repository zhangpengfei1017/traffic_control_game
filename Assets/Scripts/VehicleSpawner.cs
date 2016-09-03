using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpawnPoint))]
public class VehicleSpawner : MonoBehaviour
{
    /// <summary>
    /// List of prefabs of vehicle to be spawned
    /// </summary>
    public WayAgent[] m_Prefabs;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2.0f);

        var vehicle = Instantiate<WayAgent>(m_Prefabs[0]);
        vehicle.transform.position = transform.position;
        vehicle.transform.rotation = transform.rotation;
        vehicle.StartPoint = GetComponent<SpawnPoint>();
    }

    void Update()
    {

    }
}
