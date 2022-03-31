using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMovement : MonoBehaviour
{
    Rigidbody rb;
    private float currentSpeed;
    private float maxSpeed = 100f;
    public float speed = 5f;
    public float verticalSpeed;
    public float turnS = 50f;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        //Lateral Movement
        if (Input.GetKey(KeyCode.W)) {
            currentSpeed += speed;
        } else if (Input.GetKey(KeyCode.S)) {
            currentSpeed -= speed;
        } else if (Mathf.Abs(currentSpeed) > 0) {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, speed);
            if (Mathf.Abs(currentSpeed) < 1) {
                currentSpeed = 0;
            }
        }
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
        rb.AddForce(transform.up * currentSpeed);

        //Rotation
        if (Input.GetKey(KeyCode.A)) {
            rb.AddTorque(transform.forward * turnS);
        } else if (Input.GetKey(KeyCode.D)) {
            rb.AddTorque(transform.forward * -turnS);
        }

        //Vertical Movement
        if (Input.GetKey(KeyCode.Space)) {
            verticalSpeed -= speed;
        } else if (Input.GetKey(KeyCode.LeftShift)) {
            verticalSpeed += speed;
        } else if (Mathf.Abs(verticalSpeed) > 0) {
            verticalSpeed = Mathf.MoveTowards(verticalSpeed, 0, speed);
            if (Mathf.Abs(verticalSpeed) < 1) {
                verticalSpeed = 0;
            }
        }
        verticalSpeed = Mathf.Clamp(verticalSpeed, -maxSpeed, maxSpeed);
        rb.AddForce(transform.forward * verticalSpeed);
    }
}
