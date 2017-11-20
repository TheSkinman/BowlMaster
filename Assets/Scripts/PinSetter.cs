using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    public GameObject pinSet;


    // This needs to be created only once
    private ActionMaster actiomMaster = new ActionMaster();

    private Animator animator;
    private PinCounter pinCounter;

    // Use this for initialization
    void Start () {
        animator = Component.FindObjectOfType<Animator>();
        pinCounter = Component.FindObjectOfType<PinCounter>();
    }

	// Update is called once per frame
	void Update () {
    }

    public void RaisePins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
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

    public void PerformAction(ActionMaster.Action action)
    {
        // Handle actions
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle end game yet.");
        }
    }
}
