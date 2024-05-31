using System;
using UnityEngine;

public class Hover : MonoBehaviour
{

    [SerializeField] private float amplitude = 0.1f;
    [SerializeField] private float speed = 2f;
    private Vector3 startPosition;
    

    private void Awake()
    {
        startPosition = transform.position;
    }
    
    private void Update()
    {
        transform.position = startPosition + new Vector3(0, Mathf.Sin(Time.time) * amplitude, 0);
    }
}
