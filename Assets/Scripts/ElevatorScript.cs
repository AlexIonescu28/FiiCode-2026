using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform elavatorTop;
    public Transform destinationTop;
    public float speed = 1.2f;
    private Vector2 originalPosition;
    private Vector2 topPosition;
    private bool goingUp = false;
    private Vector2 targetPosition;

    void Start()
    {
        if (elavatorTop != null && destinationTop != null)
        {
            originalPosition = elavatorTop.position;
            topPosition = destinationTop.position;
        }
    }

    void Update()
    {
        if (goingUp == true)
        {
            targetPosition = topPosition;
            elavatorTop.position = Vector2.MoveTowards(elavatorTop.position, targetPosition, Time.deltaTime * speed);
        }
        else
        {
            targetPosition = originalPosition;
            elavatorTop.position = Vector2.MoveTowards(elavatorTop.position, targetPosition, Time.deltaTime * speed);
        }
    }

    public void Up()
    {
        goingUp = true;
    }

    public void Down()
    {
        goingUp = false;
    }
}