using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMelonController : MonoBehaviour
{ 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("CutArea")) gameObject.tag = "Cut";
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("CutArea")) gameObject.tag = "Cut";
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("CutArea")) gameObject.tag = "Water";
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("CutArea")) gameObject.tag = "Cut";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CutArea")) gameObject.tag = "Cut";
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CutArea")) gameObject.tag = "Water";
    }
}
