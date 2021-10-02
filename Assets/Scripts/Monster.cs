using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent nav;
    public Transform eyes;

    private string state = "idle";
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }


    public void checkSight()
    {
        if (alive)
        {
            RaycastHit rayHit;
            if (Physics.Linecast(eyes.position, player.transform.position, out rayHit))
            {
                print("hit " + rayHit.collider.gameObject.name);

                if (rayHit.collider.gameObject.name == "First Person Controller")
                {
                    if (state != "kill")
                    {
                        state = "chase";
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            //Idle
            if (state == "idle")
            {
                //Pick a random place to go to
                Vector3 randomPos = Random.insideUnitSphere * 20f;
                UnityEngine.AI.NavMeshHit navHit;
                UnityEngine.AI.NavMesh.SamplePosition(transform.position + randomPos, 
                                       out navHit, 20f, UnityEngine.AI.NavMesh.AllAreas);
                nav.SetDestination(navHit.position);
                state = "walk";
            }
            //Walk
            if (state == "walk")
            {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending)
                {
                    state = "idle";
                }
            }
            //Chase
            if (state == "chase")
            {
                nav.destination = player.transform.position;
            }
        }
    }
}
