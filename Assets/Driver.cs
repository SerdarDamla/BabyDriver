using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 225f;
    [SerializeField]float movementSpeed = 14f;
    [SerializeField]float slowSpeed = 7f;
    [SerializeField]float boostSpeed = 21f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float movementAmount = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Rotate(0, 0,-steerAmount);
        transform.Translate(0,movementAmount,0);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        movementSpeed = slowSpeed;
    }
    void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "SpeedUp")
            {
                movementSpeed = boostSpeed;
                Destroy(other.gameObject);
            }
        }
}
