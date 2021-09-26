using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private float currentSize = 0; 
    [SerializeField] private Vector3 growthVector;
    public BoxCollider playerCol;
    public Transform pivotLeft;
    public Transform pivotRight;
    public Transform pivotForward;
    public Transform pivotBackward;

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
                //Box grows larger
                transform.localScale += col.gameObject.GetComponent<Collectible>().growthValue;
                Destroy(col.gameObject);
                transform.position += new Vector3(0, growthVector.y, 0);
                currentSize += col.gameObject.GetComponent<Collectible>().pointsGiven;
                pivotReposition(col);
            }
            else
            {
                //Insert code to move block back
                Debug.Log("Can't be eaten!");
            }
        }
    }

    void pivotReposition(Collision col)
    {
        pivotLeft.localPosition += new Vector3((pivotLeft.localPosition.x * col.gameObject.GetComponent<Collectible>().growthValue.x), 
        (pivotLeft.localPosition.y * col.gameObject.GetComponent<Collectible>().growthValue.y), 0);
        
        pivotRight.localPosition += new Vector3((pivotRight.localPosition.x * col.gameObject.GetComponent<Collectible>().growthValue.x), 
        (pivotRight.localPosition.y * col.gameObject.GetComponent<Collectible>().growthValue.y), 0);

        pivotForward.localPosition += new Vector3(0, (pivotForward.localPosition.y * col.gameObject.GetComponent<Collectible>().growthValue.y), 
        (pivotForward.localPosition.z * col.gameObject.GetComponent<Collectible>().growthValue.z));

        pivotBackward.localPosition += new Vector3(0, (pivotBackward.localPosition.y * col.gameObject.GetComponent<Collectible>().growthValue.y), 
        (pivotBackward.localPosition.z * col.gameObject.GetComponent<Collectible>().growthValue.z));

        //pivotLeft.position += new Vector3((playerCol.bounds.size.x/2), 0, 0);
        //pivotLeft.position += new Vector3((playerCol.bounds.size.x/2), 0, 0);
    }
}
