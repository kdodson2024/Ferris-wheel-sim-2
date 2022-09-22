using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class zoom : MonoBehaviour
{
    public Slider zoomSlide;
    public Camera camComponent;
    public bool changing;
    public GameObject wheelCargo;
    // Start is called before the first frame update
    void Start()
    {
        changing = false;
        camComponent = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(changing){
            //transform.Translate((wheelCargo.transform.position.x - transform.position.x) / -4, (wheelCargo.transform.position.y - transform.position.y) / -4, (wheelCargo.transform.position.z - transform.position.z) / -4);
        //}
       // else{
            transform.position = new Vector3(transform.position.x, transform.position.y, 20.5f - zoomSlide.value);
        //}
        camComponent.fieldOfView = 67.5f - zoomSlide.value;
    }
    public IEnumerator changeCamTransition(){
        changing = true;
        yield return new WaitForSecondsRealtime(0.2f);
        changing = false;
    }
}
