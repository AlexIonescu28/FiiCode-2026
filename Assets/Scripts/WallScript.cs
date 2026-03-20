using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public Transform wallTop;
    public float sinkDistance = 0.2f;
    public float speed;
    private Vector2 originalPosition;
    private Vector2 sinkedPosition;
    private Vector2 targetPosition;
    private bool goingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        if (wallTop != null)
        {
            originalPosition = wallTop.localPosition;

            sinkedPosition = originalPosition - new Vector2(0, sinkDistance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp != true)
        {
            targetPosition = sinkedPosition;
        }
        else
        {
            targetPosition = originalPosition;
        }

        wallTop.localPosition = Vector2.MoveTowards(wallTop.localPosition, targetPosition, Time.deltaTime * speed);
    }

    public void wallUp()
    {
        goingUp = true;
    }

    public void wallDown()
    {
        goingUp = false;
    }
}
