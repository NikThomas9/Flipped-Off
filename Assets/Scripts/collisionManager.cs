using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionManager : MonoBehaviour
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
            transform.localScale += col.gameObject.GetComponent<Collectible>().growthValue;
            Destroy(col.gameObject);
            transform.position += new Vector3(0, growthVector.y, 0);
        }
    }
}
