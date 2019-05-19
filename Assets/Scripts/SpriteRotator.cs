using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    // Update is called once per frame
    public float rotateX = 0f;
    public float rotateY = 0f;
    public float rotateZ = 0f;
    public float timeLength;

    void Update()
    {
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}
