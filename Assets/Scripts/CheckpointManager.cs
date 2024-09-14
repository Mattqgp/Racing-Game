using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    [SerializeField] Transform[] checkpoints;
    public int nextCheckpoint = 1;
    [SerializeField] LayerMask carLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform checkpoint = checkpoints[nextCheckpoint - 1];
        BoxCollider checkpointColl = checkpoint.GetComponent<BoxCollider>();
        Collider[] hit = Physics.OverlapBox(checkpoint.position, checkpointColl.size / 2, checkpoint.rotation, carLayer);

        if (hit.Length > 0)
        {
            Debug.Log("Next");
            if (nextCheckpoint == checkpoints.Length) nextCheckpoint = 1;
            else nextCheckpoint++;

        }

        for (int i = 0; i < checkpoints.Length; i++)
        {
            if (i != nextCheckpoint - 1)
            {
                foreach (MeshRenderer mesh in checkpoints[i].GetComponentsInChildren<MeshRenderer>())
                {
                    mesh.enabled = false;
                }
            }
            else
            {
                foreach (MeshRenderer mesh in checkpoints[i].GetComponentsInChildren<MeshRenderer>())
                {
                    mesh.enabled = true;
                }
            }
        }
    }
}
