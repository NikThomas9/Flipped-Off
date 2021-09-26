using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippedOff_collectible : MonoBehaviour
{
    public Vector3 growthValue;
    public float sizeRequired;
    public float pointsGiven;
    public bool winningCollectible;
    public FlippedOff_playerMovement player;
    private float jumpAmount;

    // Start is called before the first frame update
    void Start()
    {
        if (growthValue == null)
        {
            growthValue = new Vector3(.2f, .2f, .2f);
        }
        player = GameObject.Find("Player").GetComponent<FlippedOff_playerMovement>();
        jumpAmount = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void TriggerJump()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpAmount, 0);
    }
}
