using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnScript : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public float cameraSlack;
    public float cameraDistance;
    public float maxHeight;

    private Vector3 pivotPoint;

    void Start()
    {
        pivotPoint = transform.position;
    }

    private void OnEnable() {
        Vector3 current = pivotPoint;
        Vector3 target = player.transform.position + Vector3.up;
        pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

        transform.position = pivotPoint;
        Quaternion targetRotation = Quaternion.LookRotation((enemy.position + player.position) / 2);
     
        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSlack * Time.deltaTime);
        // transform.LookAt((enemy.position + player.position) / 2);
        transform.position -= transform.forward * cameraDistance;
    }

    void Update()
    {
        if (enemy) {
            Vector3 current = pivotPoint;
            Vector3 target = player.transform.position + Vector3.up;
            pivotPoint = Vector3.MoveTowards(current, target, Vector3.Distance(current, target) * cameraSlack);

            transform.position = pivotPoint;
            Quaternion targetRotation = Quaternion.LookRotation((enemy.position - player.position) / 2);
     
            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, cameraSlack * Time.deltaTime * 2);
            transform.position -= transform.forward * cameraDistance;

        } else {this.enabled = false;}
    }
}
