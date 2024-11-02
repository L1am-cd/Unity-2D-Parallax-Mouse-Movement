// Script originally made by Liam (GitHub: L1am-cd) 2 November 2024
// This script is free to edit and modify. 
// If you use it, credit would be appreciated, but is not needed.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxMouse : MonoBehaviour
{

    [Header("Parallax Settings")]
    public bool MoveOnX = true;
        public bool MoveOnY = true;
            public float parallaxStrength = -0.5f;
                [Range(0f, 1f)] [Tooltip("Lower is slower and more smooth")]
                public float smoothSpeedMouse = 0.03f;
                    [Range(0f, 1f)] [Tooltip("Lower is slower and more smooth")]
                    public float smoothSpeedTouch = 0.02f;

    [Header("Maximum Offset Settings")]
    public float maxOffsetX = 0.5f;
        public float maxOffsetY = 0.5f;

    [Range(0f, 50f)]
    private Vector3 targetPosition;

    [Range(0f, 50f)]
    private Vector3 initialPosition;

    [Space(10)]
    [Header("Information")]
    public Vector2 mousePosition;

    void Start()
    {

        initialPosition = transform.position;
            targetPosition = initialPosition; 

    }

    void Update()
    {

        mousePosition = Input.mousePosition;
            Vector3 viewportPosition = new Vector3(mousePosition.x / Screen.width, mousePosition.y / Screen.height, 0);
                float offsetX = MoveOnX ? Mathf.Clamp((viewportPosition.x - 0.5f) * parallaxStrength, -maxOffsetX, maxOffsetX) : 0;
                    float offsetY = MoveOnY ? Mathf.Clamp((viewportPosition.y - 0.5f) * parallaxStrength, -maxOffsetY, maxOffsetY) : 0;
                        targetPosition = initialPosition + new Vector3(offsetX, offsetY, 0);
                            if (Input.touchCount > 0) transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeedTouch); // Touch Input
                            else transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeedMouse); // Mouse Input

    }

}