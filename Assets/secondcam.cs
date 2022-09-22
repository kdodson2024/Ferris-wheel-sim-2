using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondcam : MonoBehaviour
{
    public GameObject cargo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(cargo.transform);
    }
}
