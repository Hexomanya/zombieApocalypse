using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerRotator : MonoBehaviour
{
    private enum RotationDirection { Right, Left}
    private enum MarkerSize { Big, Little }

    [SerializeField] private RotationDirection direction;
    [SerializeField] private float rotationSpeed = 25f;

    private void Update()
    {
        float rotation = 0f;

        switch (direction)
        {
            case RotationDirection.Right:
                rotation = rotationSpeed * Time.deltaTime;
                break;
            case RotationDirection.Left:
                rotation = -rotationSpeed * Time.deltaTime;
                break;
        }

        this.transform.Rotate(0, 0, rotation);
    }
}
