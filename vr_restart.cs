using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class vr_restart : MonoBehaviour
{
    public SteamVR_Action_Boolean teleport;
    public SteamVR_Action_Boolean pinch;
    public SteamVR_Action_Vibration haptice;
    public float time;
    public float set_time = 3;
    public bool check;
    // Start is called before the first frame update
    void Start()
    {
        time = set_time;
    }

    // Update is called once per frame
    void Update()
    {

        if(teleport.GetState(SteamVR_Input_Sources.Any)){
            time -= Time.deltaTime;
            if(time <= 0 ){
                pulse(0.1f, 1, 50, SteamVR_Input_Sources.Any);
                if(pinch.GetStateDown(SteamVR_Input_Sources.Any)){
                    check = true;
                    if(check == true){
                    SceneManager.LoadScene("combine_all_scene");
                    check = false;
                    }

                }
            }
        }
        else{
            time = set_time;
        }
    }

        void pulse( float durationSeconds, float frequency, float amplitude, SteamVR_Input_Sources inputSource)
    {
        haptice.Execute(0, durationSeconds, frequency, amplitude, inputSource);
    }


}
