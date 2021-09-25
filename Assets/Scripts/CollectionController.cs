using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{
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
            transform.localScale += growthVector;
            Destroy(col.gameObject);
            transform.position += new Vector3(0, growthVector.y * 5, 0);
        }
    }
}
