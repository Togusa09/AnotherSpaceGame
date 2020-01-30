using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //[SerializeField] private List<Rigidbody> ChildRigidBodies = new List<Rigidbody>();

   
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var rigidBody = other.GetComponent<Rigidbody>();
    //        if (!ChildRigidBodies.Contains(rigidBody))
    //        {
    //            ChildRigidBodies.Add(rigidBody);
    //        }
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        var rigidBody = other.GetComponent<Rigidbody>();
    //        if (ChildRigidBodies.Contains(rigidBody))
    //        {
    //            ChildRigidBodies.Remove(rigidBody);
    //        }
    //    }
    //}
}
