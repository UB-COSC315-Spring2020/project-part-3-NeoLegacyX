using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Sawneek;
    public float camdistance = 30.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / camdistance);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(Sawneek.position.x, Sawneek.position.y, transform.position.z);
    }
}
