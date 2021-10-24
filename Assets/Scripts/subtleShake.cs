using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class subtleShake : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          CameraShaker.Instance.ShakeOnce(1.0f,0.02f,0.5f,.5f);
    }
}
