using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTransStart; //Give it player spawn position
    Transform playerTrans; //Player transform after instaciation

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothness = 0.5f;

    void Start()
    {
        cameraOffset = transform.position - playerTransStart.position;
    }

    void Update()
    {
        playerTrans = GameObject.Find("Player(Clone)").transform;
        Vector3 newPos = playerTrans.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
    }
}