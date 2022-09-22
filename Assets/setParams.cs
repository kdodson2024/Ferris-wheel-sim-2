using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setParams : MonoBehaviour
{
    public float radius;
    public float rotationPeriod;
    public GameObject arm1;
    public GameObject arm2;
    public GameObject car;
    public moveCar carMove;
    public Slider radSlide;
    public Slider perSlide;
    public float timeT;
    public Text timeText;
    public Text radText;
    public Text perText;
    public Text setPeriod;
    public Text setRadius;
    // Start is called before the first frame update
    void Start()
    {
        timeT = 0 - (rotationPeriod * 3);
        carMove = car.GetComponent<moveCar>();
        carMove.radius = radius;
        carMove.period = rotationPeriod;
        arm1.transform.localScale = new Vector3(0.4075588f, 1, 2 * radius);
        arm2.transform.localScale = new Vector3(0.4075588f, 1, 2 * radius);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeT += Time.deltaTime;
        timeText.text = timeT + "";
        radText.text = radius + "";
        perText.text = rotationPeriod + "";
        radius = radSlide.value;
        rotationPeriod = perSlide.value;
        carMove.radius = radius;
        carMove.period = rotationPeriod;
        arm1.transform.localScale = new Vector3(0.4075588f, 1, 2 * radius);
        arm2.transform.localScale = new Vector3(0.4075588f, 1, 2 * radius);
        transform.eulerAngles = new Vector3(Mathf.Rad2Deg * (-6.2831853f/rotationPeriod) * timeT, -90, -90);
    }
    public void changeRadius()
    {
        radius = float.Parse(setRadius.text);
        radSlide.value = radius;
        carMove.radius = radius;
        reset();
        reset();
        makeResetWork();
    }
    public void changePeriod()
    {
        rotationPeriod = float.Parse(setPeriod.text);
        perSlide.value = rotationPeriod;
        carMove.period = rotationPeriod;
        reset();
        reset();
        makeResetWork();
    }
    public void reset()
    {
        if(rotationPeriod <= 5){
            timeT = 0 - (rotationPeriod * 3);
        }
        else if(rotationPeriod <= 7.5f){
            timeT = 0 - (rotationPeriod * 2);
        }
        else if(rotationPeriod <= 15.0f){
            timeT = 0 - (rotationPeriod);
        }
        else{
            timeT = 0;
        }
        
        carMove.reset();
    }
    public IEnumerator makeResetWork(){
        yield return new WaitForSecondsRealtime(0.01f);
        reset();
        carMove.reset();
    }
}
