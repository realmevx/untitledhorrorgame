using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggle : MonoBehaviour
{
    

    public GameObject ObjectOne;
    public AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
         
         
        
    }

    // Update is called once per frame
    void Update()
{
    if (Input.GetKeyDown(KeyCode.F))
    {
        
        audioData.Play();
        //Get current State
        bool currentState = ObjectOne.activeSelf;

        //Flip it
        currentState = !currentState;

        //Set the current State to the flipped value
        ObjectOne.SetActive(currentState);
    }
}
}

