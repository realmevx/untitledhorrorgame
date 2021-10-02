using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonster : MonoBehaviour
{
    public bool alive = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FOV")
        {
            other.transform.parent.GetComponent<Monster>().checkSight();
        }
    }
}
