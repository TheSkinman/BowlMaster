using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

    private void OnTriggerExit(Collider other)
    {
        GameObject thigLeft = other.gameObject;
        if (thigLeft.GetComponent<Pin>())
        {
            Destroy(thigLeft);
        }
    }
}
