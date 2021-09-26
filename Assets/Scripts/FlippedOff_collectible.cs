using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippedOff_collectible : MonoBehaviour
{
    public Vector3 growthValue;
    public float sizeRequired;
    public float pointsGiven;
    public bool winningCollectible;

    // Start is called before the first frame update
    void Start()
    {
        if (growthValue == null)
        {
            growthValue = new Vector3(.2f, .2f, .2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
