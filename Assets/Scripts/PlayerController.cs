using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform selfTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private Transform BulletSpawnerTransform;
    [SerializeField] private Transform sphereHolderTransform;

    [SerializeField] private float camSpeed = 0.5f;
    [SerializeField] private float camSens = 0.5f;
    [SerializeField] private float playerSpeed = 0.2f;
    [SerializeField] private float bulletSpeed = 3000f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotateCamera();
        Shoot();
    }
    
    private void MovePlayer()
    {
        Vector3 camRight = cameraTransform.right;
        Vector3 camForward = cameraTransform.forward;

        Vector3 deltaPosition = new Vector3(camRight.x,0f,camRight.z) * Input.GetAxis("Horizontal") + new Vector3(camForward.x, 0f, camForward.z) * Input.GetAxis("Vertical");
        selfTransform.position += deltaPosition * playerSpeed;
        
        playerRigidbody.MovePosition(playerRigidbody.position + deltaPosition * playerSpeed);
    }

    private void RotateCamera()
    {
        float pitch = -Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch,-90f, 90f);

        float yawn = Input.GetAxis("Mouse X");
        
        yawn += yawn * camSens;
        pitch += pitch * camSpeed;
        cameraTransform.localEulerAngles += new Vector3(pitch, yawn, 0f);
    }

    private void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = (GameObject) Instantiate(Resources.Load("Bullet"),BulletSpawnerTransform.position,Quaternion.identity,sphereHolderTransform);
            bullet.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * bulletSpeed);
        }
    }
}
