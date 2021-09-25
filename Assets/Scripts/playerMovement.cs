using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public GameObject pivotPoints;
    private bool moving = false;
    public Vector3 direction;
    private float totalRotation = 0f;
    public Vector3 rotateAxis;

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
            transform.RotateAround(direction, rotateAxis, rotateSpeed * Time.deltaTime);
            totalRotation += rotateSpeed * Time.deltaTime;
        }
        if(totalRotation >= 90f)
        {
            moving = false;
            totalRotation = 0f;
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
