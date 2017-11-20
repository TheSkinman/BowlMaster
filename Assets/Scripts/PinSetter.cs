using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public Text standingDisplay;
    public GameObject pinSet;

    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;

    // This needs to be created only once
    private ActionMaster actiomMaster = new ActionMaster();

    private Ball ball;
    private Animator animator;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
        animator = Component.FindObjectOfType<Animator>();
    }

	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    public void SetBallOutOfPlay()
    {
        ballOutOfPlay = true;
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
            pin.transform.rotation = Quaternion.Euler(270f, 0, 0);
        }
    }

    public void RenewPins()
    {
        GameObject currentPins = GameObject.Find("Pins");
        Destroy(currentPins);
        currentPins = GameObject.Find("Pins(Clone)");
        Destroy(currentPins);
        GameObject newPins = Instantiate(pinSet);
        foreach (Pin pin in newPins.GetComponentsInChildren<Pin>())
        {
            pin.Renew();
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    void UpdateStandingCountAndSettle()
    {
        // Update the lastStandingCount
        // Call PinsHaveSettled() when they have
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consider pins settled
        if ((Time.time - lastChangeTime) > settleTime) // If last change is > 3s ago
        {
            PinsHaveSettled();
        }

    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        ActionMaster.Action action = actiomMaster.Bowl(pinFall);
        Debug.Log("Pinfall: [" + pinFall + "] / Action: [" + action + "]");

        // Handle actions
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;

        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet.");
        }

        ball.Reset();
        ballOutOfPlay = false;
        lastStandingCount = -1; // Indicates pins have settled, and ball not back in box
        standingDisplay.color = Color.green;
    }

    public int CountStanding()
    {
        int standing = 0;
        foreach(Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }
}
