using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    private Animator anim = null;
    //public Transform Player;
    int MaxDist = 10;
    int MinDist = 5;

    // Start is called before the first frame update
    void Start()
    {
        RagDoll(true);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    //takes a bool value and loops through all the children of the zombie
    void RagDoll(bool value)
    {
        var bodyParts = GetComponentsInChildren<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        foreach(var bodyPart in bodyParts)
        {
            bodyPart.isKinematic = value;
        }
    }

    //function to kill the zombie
    void KillZombie(RaycastHit hitLocationInfo)
    {
        GetComponent<Animator>().enabled = false;
        RagDoll(false);
        Vector3 hitPoint = hitLocationInfo.point;

        var colliders = Physics.OverlapSphere(hitPoint, 0.5f);

        foreach(var collider in colliders)
        {
            var rigidBody = collider.GetComponent<Rigidbody>();
            if(rigidBody)
            {
                rigidBody.AddExplosionForce(1000, hitPoint, 0.5f);
            }
        }
        this.enabled = false;
    }

    void Run()
    {
        //transform.LookAt(Player);

        //forward direction to the player
        transform.forward = Vector3.ProjectOnPlane((Camera.main.transform.position - transform.position), Vector3.up).normalized;

        //if (Vector3.Distance(transform.position,Camera.main.transform.position) <= MaxDist)
        //{
            //called every frame
            transform.position += Time.deltaTime * transform.forward * 5;
       // }

        //if(Vector3.Distance(transform.position, Camera.main.transform.position) <= MaxDist)
      //  {

        //}
        
        
        //anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);
    }
}
