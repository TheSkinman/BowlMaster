using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 10f;
    public float distanceToRaise = 40f;

    private Rigidbody rigid_body;

    private void Awake()
    {
        rigid_body = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(270 - rotationInEuler.z);

        if (tiltInX < standingThreshold || tiltInX > 360f - standingThreshold && 
            tiltInZ < standingThreshold || tiltInZ > 360f - standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigid_body.useGravity = false;
            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void Renew()
    {
        rigid_body.useGravity = false;
        transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, -distanceToRaise, 0), Space.World);
        rigid_body.useGravity = true;
    }
}
