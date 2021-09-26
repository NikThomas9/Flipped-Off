using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] private GameObject pivotPoints;
    private bool moving = false;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public float totalRotation = 0f;
    [HideInInspector] public Vector3 rotateAxis;

    public int rotateSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetMoveDirection();
        if (moving) 
        {
            totalRotation += rotateSpeed * Time.deltaTime;
            if(totalRotation > 90f)
            {
                transform.RotateAround(direction, rotateAxis, rotateSpeed * Time.deltaTime - (totalRotation - 90f));
            }    
            else
            {
                transform.RotateAround(direction, rotateAxis, rotateSpeed * Time.deltaTime);
            } 
        }
        if(totalRotation >= 90f)
        {
            moving = false;
            totalRotation = 0f;
            transform.position = new Vector3(transform.position.x, transform.lossyScale.y / 2, transform.position.z);
        }
    }

    private void GetMoveDirection()
    {
        if (!moving)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moving = true;
                direction = pivotPoints.transform.GetChild(0).position;
                rotateAxis = Vector3.right;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moving = true;
                direction = pivotPoints.transform.GetChild(1).position;
                rotateAxis = Vector3.forward;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moving = true;
                direction = pivotPoints.transform.GetChild(2).position;
                rotateAxis = Vector3.back;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moving = true;
                direction = pivotPoints.transform.GetChild(3).position;
                rotateAxis = Vector3.left;
            }

        }
        
    }
}
