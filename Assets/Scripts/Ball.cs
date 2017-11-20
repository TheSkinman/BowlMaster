using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Vector3 ballStartPos;
    private Rigidbody rigid_body;
    private AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        rigid_body = GetComponent<Rigidbody>();
        rigid_body.useGravity = false;
        ballStartPos = transform.position;
    }

    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigid_body.useGravity = true;
        rigid_body.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigid_body.velocity = Vector3.zero;
        rigid_body.angularVelocity = Vector3.zero;
        rigid_body.useGravity = false;
    }
}
