using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject cam;
    Vector3 camlocalPos1;
    public float smoothCamSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        camlocalPos1 = cam.GetComponent<Transform>().localPosition;
    }


    // Update is called once per frame
    void LateUpdate(){
        Vector3 camPosition2 = transform.localPosition;
        //Debug.Log(transform.localPosition);
        if (Input.GetAxis("Horizontal") > 0){
            transform.localPosition = new Vector3(6f * Input.GetAxis("Horizontal") * smoothCamSpeed, 1.5f, -10f);
        }
       
       if (Input.GetAxis("Horizontal") < 0)
        {
           transform.localPosition = new Vector3(-6f * Input.GetAxis("Horizontal") * smoothCamSpeed, 1.5f, -10f);
        }
        
    }


    /*
         public Transform target;
    public float smoothCamSpeed = 0.125f;
    public Vector3 offset;
            Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothCamSpeed);
        transform.position = smoothedPos;
    */



}
