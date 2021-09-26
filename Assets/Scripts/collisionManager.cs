using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
{
    [SerializeField] private float currentSize = 0; 
    [SerializeField] private Vector3 growthVector;
    // Start is called before the first frame update
    void Start()
    {
        
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
                transform.localScale += col.gameObject.GetComponent<Collectible>().growthValue;
                Destroy(col.gameObject);
                transform.position += new Vector3(0, growthVector.y, 0);
                currentSize += col.gameObject.GetComponent<Collectible>().pointsGiven;
            }
            else
            {
                //Insert code to move block back
                Debug.Log("Can't be eaten!");
            }
        }
    }
}
