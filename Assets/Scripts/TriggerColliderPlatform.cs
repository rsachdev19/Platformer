using UnityEngine;
using System.Collections;

public class TriggerColliderPlatform : MonoBehaviour
{
    private GameObject target = null;
    private Vector3 offset;
    void Start()
    {
        target = null;
    }
    void OnTriggerStay(Collider col)
    {
        target = col.gameObject;
        offset = target.transform.position - transform.position;
    }
    void OnTriggerExit(Collider col)
    {
        target = null;
    }
    void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }
    /*
    public MovingThing platformParent;

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Debug.Log("on platform");
            other.gameObject.transform.parent = platformParent.gameObject.transform;
        }


        //Only parent the artifact to this if it is not already parented AKA if it's not
        //already being held by the player
        if (other.tag.Equals("Artifact"))
        {
            if (other.gameObject.transform.parent == null)
            {
                other.gameObject.transform.parent = platformParent.gameObject.transform;
            }
            //Debug.Log("on platform");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.gameObject.transform.parent = null;
            // Debug.Log("left platform");
        }
        if (other.tag.Equals("Artifact"))
        {
            if (other.gameObject.transform.parent != null &&
                !other.gameObject.transform.parent.tag.Equals("MainCamera") &&
                !other.gameObject.transform.parent.tag.Equals("Slot"))
            {
                other.gameObject.transform.parent = null;
            }
        }
    }
    */
}
