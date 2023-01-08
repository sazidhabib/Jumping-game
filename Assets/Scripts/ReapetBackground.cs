using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapetBackground : MonoBehaviour
{
    private Vector3 startPso;
    private float reapetWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPso = transform.position;
        reapetWidth = GetComponent<BoxCollider>().size.x/2;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPso.x - reapetWidth) 
        {
            transform.position = startPso;
        }
    }
}
