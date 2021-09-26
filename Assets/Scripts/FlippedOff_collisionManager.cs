using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippedOff_collisionManager : MonoBehaviour
{
    [SerializeField] private float currentSize = 0; 
    public BoxCollider playerCol;
    public Transform pivotLeft;
    public Transform pivotRight;
    public Transform pivotForward;
    public Transform pivotBackward;
    public FlippedOff_cameraShake shakeController;
    private Vector3 growthValue;

    // Start is called before the first frame update
    void Start()
    {
        playerCol = gameObject.GetComponent<BoxCollider>();
        Debug.Log(GameController.Instance.gameDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Collectible")
        {
            if (currentSize >= col.gameObject.GetComponent<FlippedOff_collectible>().sizeRequired)
            {
                if (col.gameObject.GetComponent<FlippedOff_collectible>().winningCollectible)
                    GameController.Instance.WinGame();
                //Box grows larger
                growthValue = col.gameObject.GetComponent<FlippedOff_collectible>().growthValue;
                transform.localScale += growthValue;
                shakeController.shakeMagnitude += 0.05f;

                Destroy(col.gameObject);
                currentSize += col.gameObject.GetComponent<FlippedOff_collectible>().pointsGiven;
                pivotReposition();
            }
            else
            {
                reverseDirection();

                Debug.Log("Can't be eaten!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
            reverseDirection();
    }

    void reverseDirection()
    {
        print("reversing direction");
        FlippedOff_playerMovement player = playerCol.gameObject.GetComponent<FlippedOff_playerMovement>();

        //reverse direction of rotation
        if (player.rotateAxis == Vector3.right || player.rotateAxis == Vector3.left)
            player.direction.x = -player.direction.x;
        else
            player.direction.z = -player.direction.z;

        //reverse axis of rotation
        player.rotateAxis = -player.rotateAxis;

        //set rotation amount to the remained of the original rotation
        player.totalRotation = 90f - player.totalRotation;
    }

    void pivotReposition()
    {
        pivotLeft.localPosition = new Vector3(-playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2, 0);

        pivotBackward.localPosition = new Vector3(0, -playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2);

        pivotForward.localPosition = new Vector3(0, -playerCol.transform.localScale.x / 2, playerCol.transform.localScale.x / 2);

        pivotRight.localPosition = new Vector3(playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2, 0);
    }
}
