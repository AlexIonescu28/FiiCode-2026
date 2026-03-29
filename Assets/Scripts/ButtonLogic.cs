using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonLogic : MonoBehaviour
{
    public Transform buttonTop;
    public bool isPressed = false;
    private int collisionCount = 0;
    public float sinkDistance = 0.2f; 
    public float pressSpeed = 5f;
    private Vector2 originalPosition;
    private Vector2 pressedPosition;
    private Vector2 targetPosition;
    public UnityEvent pressed;   
    public UnityEvent notPressed;

    // Start is called before the first frame update
    void Start()
    {
        if (buttonTop != null)
        {
            originalPosition = buttonTop.localPosition;
            
            pressedPosition = originalPosition - new Vector2(0, sinkDistance);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        if (buttonTop != null)
        {
           
            if (isPressed == true)
            {
                
                targetPosition = pressedPosition;
            }
            else
            {
                
                targetPosition = originalPosition;
            }
        }

        buttonTop.localPosition = Vector2.Lerp(buttonTop.localPosition, targetPosition, Time.deltaTime * pressSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("player") || collision.CompareTag("Destroyable object"))
        {
            isPressed = true;
            collisionCount++;
            pressed.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player") || collision.CompareTag("Destroyable object"))
        {
            collisionCount--;
            if(collisionCount == 0)
            {
                isPressed = false;
                notPressed.Invoke();
            }
        }
    }
}
