using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolCart : MonoBehaviour
{
    public Slider distanceSlide;
    public Slider lengthSlide;
    public Slider speedSlide;
    public GameObject wheel;
    public setParams wheelScript;
    public GameObject track;
    public Text distanceText;
    public Text lengthText;
    public Text speedText;
    public bool moving;
    public Slider scaleSlide;
    public Text scaleText;
    // Start is called before the first frame update
    void Start()
    {
        wheelScript = wheel.GetComponent<setParams>();
        transform.position = new Vector3(track.transform.localScale.z, 5 - wheelScript.radius + distanceSlide.value, transform.position.z);
        moving = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceText.text = distanceSlide.value + "";
        lengthText.text = lengthSlide.value + "";
        speedText.text = speedSlide.value + "";
        track.transform.localScale = new Vector3(track.transform.localScale.x, track.transform.localScale.y, lengthSlide.value);
        track.transform.position = new Vector3((track.transform.localScale.z / 2), (5 - wheelScript.radius + distanceSlide.value) - 1.15f, track.transform.position.z);
        transform.position = new Vector3(transform.position.x, 5 - wheelScript.radius + distanceSlide.value, transform.position.z);
        transform.localScale = new Vector3(scaleSlide.value, 1, scaleSlide.value);
        scaleText.text = scaleSlide.value + "";
        if(Mathf.Abs(0 - wheelScript.timeT) <= 1.3 * Time.deltaTime){
            moving = true;
        }
        if(moving){
            transform.Translate(-speedSlide.value * Time.deltaTime, 0, 0);
        }
    }
    public void reset(){
        transform.position = new Vector3(track.transform.localScale.z, 5 - wheelScript.radius + distanceSlide.value, transform.position.z);
        moving = false;
    }
}
