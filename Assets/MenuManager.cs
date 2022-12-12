using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToShowStartButton());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator waitToShowStartButton(){
        yield return new WaitForSecondsRealtime(12.0f);
        startButton.SetActive(true);
    }
    public void loadMenu(){
        SceneManager.LoadScene(1);
    }
}
