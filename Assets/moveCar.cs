using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveCar : MonoBehaviour
{
    public float radius;
    public float period;
    public Rigidbody rigid;
    public Vector3 lastFramePos;
    public Vector3 thisFramePos;
    public bool attatched;
    public float timeC;
    public float timeToRelease;
    public bool useTime;
    public Text setTime;
    public Text relTime;
    public GameObject MainCam;
    public GameObject sloCam;
    public GameObject cartCam;
    public GameObject cart;
    public PoolCart cartScript;
    public GameObject confetti;
    // Start is called before the first frame update
    void Start()
    {
        confetti.SetActive(false);
        useTime = false;
        timeC = 0 - (period * 3);
        rigid = GetComponent<Rigidbody>();
        attatched = true;
        cartScript = cart.GetComponent<PoolCart>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(1/Time.deltaTime);
        relTime.text = timeToRelease + "";
        timeC += Time.deltaTime;
        //Debug.Log((thisFramePos.x - lastFramePos.x) / Time.deltaTime + " " + (thisFramePos.y - lastFramePos.y) / Time.deltaTime + " " + (thisFramePos.z - lastFramePos.z) / Time.deltaTime);
        lastFramePos = thisFramePos;
        thisFramePos = transform.position;
        rigid.isKinematic = attatched;
        rigid.useGravity = !attatched;
        if(useTime && Mathf.Abs(timeToRelease - timeC) < 0.5f){
            Time.timeScale = 0.1f;
            MainCam.SetActive(false);
            sloCam.SetActive(true);
            cartCam.SetActive(false);
        }
        else if(useTime && timeToRelease - timeC > -1.5f && timeToRelease - timeC < -0.5f){
            Time.timeScale = 0.2f;
            MainCam.SetActive(false);
            sloCam.SetActive(false);
            cartCam.SetActive(true);
        }
        else{
            Time.timeScale = 1.0f;
            MainCam.SetActive(true);
            sloCam.SetActive(false);
            cartCam.SetActive(false);
        }
        if(useTime && Mathf.Abs(timeToRelease - timeC) <= 1.3 * Time.deltaTime){
            release();
        }
        if(Input.GetKeyDown(KeyCode.Space))
            release();
        if(attatched){
            transform.position = new Vector3(0 - (radius * Mathf.Cos((6.2831853f/period) * timeC)), radius * Mathf.Sin((6.2831853f/period) * timeC) + 5, -6.7f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
            
    }
    public void release()
    {
        attatched = false;
        rigid.isKinematic = attatched;
        rigid.useGravity = !attatched;
        rigid.velocity = new Vector3((thisFramePos.x - lastFramePos.x) / Time.deltaTime, (thisFramePos.y - lastFramePos.y) / Time.deltaTime, (thisFramePos.z - lastFramePos.z) / Time.deltaTime);
        
    }
    public void reset(){
        if(period <= 5){
            timeC = 0 - (period * 3);
        }
        else if(period <= 7.5f){
            timeC = 0 - (period * 2);
        }
        else if(period <= 15.0f){
            timeC = 0 - (period);
        }
        else{
            timeC = 0;
        }
        attatched = true;
        cartScript.reset();
        confetti.SetActive(false);
    }
    public void recieveInput(){
        useTime = true;
        timeToRelease = float.Parse(setTime.text);
    }
    private void OnTriggerEnter(Collider collided){
        if(collided.gameObject.tag == "target"){
            //waitForConfetti();
            confetti.SetActive(true);
            Debug.Log("yeetus");
        }
    }
    public IEnumerator waitForConfetti(){
        Debug.Log("start waiting");
        yield return new WaitForSecondsRealtime(10.0f);
        Debug.Log("done waiting");
        confetti.SetActive(true);
    }
}