using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera2 : MonoBehaviour
{
    public float speed = 5f; // Kecepatan pergerakan kamera
    public float sensitivity = 2f; // Sensitivitas mouse untuk rotasi kamera

    private float rotationX = 0f; // Rotasi kamera pada sumbu X

    void Update()
    {
        // Mengambil input dari tombol-tombol untuk pergerakan
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float upInput = Input.GetKey(KeyCode.Space) ? 1f : 0f;
        float downInput = Input.GetKey(KeyCode.LeftShift) ? 1f : 0f;

        // Menghitung vektor gerakan berdasarkan input
        Vector3 movement = new Vector3(horizontalInput, upInput - downInput, verticalInput) * speed * Time.deltaTime;

        // Menggerakkan kamera berdasarkan vektor gerakan
        transform.Translate(movement);

        // Mengambil input dari mouse untuk rotasi kamera
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotasi kamera pada sumbu Y (horizontal) berdasarkan input mouse X
        transform.Rotate(Vector3.up, mouseX);

        // Rotasi kamera pada sumbu X (vertikal) dengan batasan sudut tertentu
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);
    }
}

