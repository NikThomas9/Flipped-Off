using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private float currentSize = 0; 
    public BoxCollider playerCol;
    public Transform pivotLeft;
    public Transform pivotRight;
    public Transform pivotForward;
    public Transform pivotBackward;
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
            if (currentSize >= col.gameObject.GetComponent<Collectible>().sizeRequired)
            {
                if (col.gameObject.GetComponent<Collectible>().winningCollectible)
                    GameController.Instance.WinGame();
                //Box grows larger
                growthValue = col.gameObject.GetComponent<Collectible>().growthValue;
                transform.localScale += growthValue;
                Destroy(col.gameObject);
                currentSize += col.gameObject.GetComponent<Collectible>().pointsGiven;
                pivotReposition();
            }
            else
            {
                //Insert code to move block back
                Debug.Log("Can't be eaten!");
            }
        }
    }

    void pivotReposition()
    {
        pivotLeft.localPosition = new Vector3(-playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2, 0);

        pivotBackward.localPosition = new Vector3(0, -playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2);

        pivotForward.localPosition = new Vector3(0, -playerCol.transform.localScale.x / 2, playerCol.transform.localScale.x / 2);

        pivotRight.localPosition = new Vector3(playerCol.transform.localScale.x / 2, -playerCol.transform.localScale.x / 2, 0);
    }
}
