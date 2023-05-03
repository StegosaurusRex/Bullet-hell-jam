using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    
    
    public float speed = 0.5f; // Скорость движения слоя
    public float movingDistance = 0.5f; // Скорость движения слоя

    private float startPosition; // Начальная позиция слоя

    private void Start()
    {
        startPosition = transform.position.x;
    }

    private void Update()
    {
        // Смещаем объект влево на заданную скорость
        float newPosition = Mathf.Repeat(Time.time * -speed , (transform.localScale.x*movingDistance));
        transform.position = new Vector3(startPosition + newPosition , transform.position.y , transform.position.z);
    }
}
