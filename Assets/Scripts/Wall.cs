using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] GameObject normalWall;
    [SerializeField] GameObject destroyedWall;
    [Space]
    public bool isCurrentlyNormalWall;
    public bool isWallDestroyed;
    public float wallDestroyDistance;
    [Space]
    [SerializeField] LayerMask carLayer;

    // Start is called before the first frame update
    void Start()
    {
        if (!isCurrentlyNormalWall && !isWallDestroyed)
        {
            Wall wall = Instantiate(normalWall, transform.position, transform.rotation).GetComponent<Wall>();
            wall.isCurrentlyNormalWall = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, wallDestroyDistance, carLayer);

        if (coll != null && coll.Length > 0)
        {
            Wall wall = Instantiate(destroyedWall, transform.position, transform.rotation).GetComponent<Wall>();
            wall.isCurrentlyNormalWall = false;
            wall.isWallDestroyed = true;
            Destroy(gameObject);
        }
    }
}
