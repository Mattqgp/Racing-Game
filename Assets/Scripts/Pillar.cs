using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] Transform pillar;
    public Vector3 localInPos;
    public Vector3 localOutPos;
    [Space]
    public float timeIn;
    public float timeOut;
    public bool isUnder;

    float timer = 0;
    [Space]
    [Range(0, 1)] public float transitionSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnder)
        {
            if (timer < timeIn)
            {
                timer += Time.deltaTime;
            }
            else
            {
                pillar.localPosition = Vector3.Lerp(pillar.localPosition, localOutPos, transitionSpeed);
                if (pillar.localPosition == localOutPos)
                {
                    timer = 0;
                    isUnder = false;
                }
            }
        }
        else
        {
            if (timer < timeOut)
            {
                timer += Time.deltaTime;
            }
            else
            {
                pillar.localPosition = Vector3.Lerp(pillar.localPosition, localInPos, transitionSpeed);
                if (pillar.localPosition == localInPos)
                {
                    timer = 0;
                    isUnder = true;
                }
            }
        }
    }
}
