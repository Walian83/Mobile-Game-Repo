using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScaler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button button;
    private Vector3 originalScale;
    private bool isPressed = false;

    private void Start()
    {
        button = GetComponent<Button>();

        // Store the original scale of the button
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Check if the button is pressed
        if (isPressed)
        {
            // Scale the button up when held down
            transform.localScale = originalScale * 1.2f; // You can adjust the scale factor as needed
        }
        else
        {
            // Scale back to the original size when released
            transform.localScale = originalScale;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // The button is pressed, the variable changes to true
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // The button is released, the variable changes to false
        isPressed = false;
    }
}
