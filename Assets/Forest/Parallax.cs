using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds Parallax effect
/// </summary>
public class Parallax : MonoBehaviour
{
    public Camera cam;
    public Transform subject;

    Vector2 startPosition;
    float startZ;


    Vector2 travel => (Vector2)cam.transform.position - startPosition; // distance moved from camera to original sprite
    Vector2 parallaxVector;

    float distanceFromSubject => transform.position.z - subject.position.z;
    float clippingPlane => cam.transform.position.z + (distanceFromSubject > 0 ? cam.farClipPlane : cam.nearClipPlane);

    float parallaxFactor => Mathf.Abs(distanceFromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = transform.position = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }
}
