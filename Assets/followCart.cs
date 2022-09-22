using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCart : MonoBehaviour
{
    public GameObject cartToFollow;
    public Vector3 relationship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cartToFollow.transform.position.x + relationship.x, cartToFollow.transform.position.y + relationship.y, cartToFollow.transform.position.z + relationship.z);
    }
}
