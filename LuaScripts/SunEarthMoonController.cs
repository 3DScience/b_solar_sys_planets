using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunEarthMoonController : MonoBehaviour {

    private int current_state = 1;

    private GameObject Earth_Moon_Rotate;
    private GameObject Earth_Moon_State1, Earth_Moon_State2, Earth_Moon_State3, Earth_Moon_State4;

    // Use this for initialization
    void Start () {
        Earth_Moon_Rotate = transform.FindChild("Earth_Moon").gameObject;
        Earth_Moon_State1 = transform.FindChild("Earth_Moon_1").gameObject;
        Earth_Moon_State2 = transform.FindChild("Earth_Moon_2").gameObject;
        Earth_Moon_State3 = transform.FindChild("Earth_Moon_3").gameObject;
        Earth_Moon_State4 = transform.FindChild("Earth_Moon_4").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space")) { 
            if(current_state == 4)
                StartCoroutine(goToState(1));
            else
                StartCoroutine(goToState(current_state + 1));
        }
    }

    private IEnumerator goToState(int state)
    {
        //Play animation open page
        Animation animation1 = GetComponent<Animation>();
        animation1.Play("state" + current_state);

        Earth_Moon_Rotate.SetActive(true);

        switch (current_state)
        {
            case 1:
                Earth_Moon_State1.SetActive(false);
                break;
            case 2:
                Earth_Moon_State2.SetActive(false);
                break;
            case 3:
                Earth_Moon_State3.SetActive(false);
                break;
            case 4:
                Earth_Moon_State4.SetActive(false);
                break;
        }
  
        do
        {
            yield return null;
        } while (animation1.isPlaying);

        Animation animation2 = GetComponent<Animation>();
        animation2.Play("static");

        Earth_Moon_Rotate.SetActive(false);

        switch (current_state)
        {
            case 1:
                Earth_Moon_State2.SetActive(true);
                break;
            case 2:
                Earth_Moon_State3.SetActive(true);
                break;
            case 3:
                Earth_Moon_State4.SetActive(true);
                break;
            case 4:
                Earth_Moon_State1.SetActive(true);
                break;
        }

        current_state++;
        if (current_state > 4)
            current_state = 1;

        if(current_state != state)
            StartCoroutine(goToState(state));
    }
}
