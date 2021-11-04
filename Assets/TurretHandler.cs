using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHandler : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float shootingRange = 7f;
    [SerializeField] private float gunDamage = 1f;
    [SerializeField] private float gunCoolDown = 1f;

    private Vector3 pivotPos;

    private void Start()
    {
        pivotPos = this.gameObject.transform.parent.position;
    }

    private void Update()
    {
        //Implement rotate around https://answers.unity.com/questions/1716346/how-do-i-rotate-a-game-object-around-a-custom-pivo.html
    }
}
