using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right);
        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.name);
        }
    }
}
