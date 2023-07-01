using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    [SerializeField]
    Transform player; // There might be better ways to "link" these
    public float detectionRange = 10f;
    public float rotationSpeed = 2f;

    [SerializeField]
    GameObject Arrow;
    public float shootingForce = 10f;

    public float shootingInterval = 5f;
    private float shootingTimer;

    private Quaternion targetRotation;

    private void Start()
    {
        shootingTimer = shootingInterval;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            targetRotation = Quaternion.LookRotation(direction) * Quaternion.Euler(-90, 90, 0); // what if you switch order?
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        if (distance <= detectionRange && shootingTimer <= 0f)
        {
            Shoot();
            shootingTimer = shootingInterval;
        }
        shootingTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(Arrow, transform.position, transform.rotation * Quaternion.Euler(180, 90, 0));
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.AddForce(arrow.transform.forward * shootingForce, ForceMode.Impulse);
    }
}