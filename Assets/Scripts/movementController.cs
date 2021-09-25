using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    public float smooth = 1f;
    private Quaternion targetRotation;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            targetRotation *= Quaternion.AngleAxis(-90, Vector3.forward);
            targetPosition += new Vector3(1, 0, 0);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 10 * smooth * Time.deltaTime);
    }
}
