using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointObject : MonoBehaviour
{
    public int points;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            PointManager.Instance.AddPoint(points);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            PointManager.Instance.AddPoint(points);
        }
    }
}
