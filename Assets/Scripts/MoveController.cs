using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Vector3 targetPos;
    public float moveSpeed;

    private Rigidbody rb;

    void Start()
    {
        targetPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - Camera.main.transform.position.z);
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);
        Vector3 followXonly = new Vector3(targetPos.x, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, followXonly, 2.0f * Time.deltaTime);
        rb.AddForce(0, 0, moveSpeed * Time.deltaTime);
    }
}