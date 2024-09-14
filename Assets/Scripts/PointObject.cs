using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PointObject : MonoBehaviour
{
    public int points;
    [Header("Popup")]
    [SerializeField] GameObject popupText;
    public Vector3 popupOffset = new(0, 2, 0);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            AddPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            AddPoint();
        }
    }

    void AddPoint()
    {
        PointManager.Instance.AddPoint(points);

        Vector3 popupSpawnPos = transform.position + popupOffset;
        TextMeshPro text = Instantiate(popupText, popupSpawnPos, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        text.transform.parent.LookAt(Camera.main.transform);
        string textIncrementValue = points >= 0 ? "+" : "-";
        text.text = textIncrementValue + " " + Mathf.Abs(points);
        Destroy(text.gameObject, 1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + popupOffset, .3f);
    }
}
