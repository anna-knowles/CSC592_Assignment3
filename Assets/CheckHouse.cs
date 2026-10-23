using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using Oculus.Interaction;
using Oculus.Interaction.Collections;

public class CheckPuzzle : MonoBehaviour
{
    public Transform targetPuzzle;
    public BirdhouseGoalManager goalManager;
    public bool isSolved;
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private BoxCollider boxCollider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, targetPuzzle.position);

        if (distance < 0.05f && !isSolved)
        {
            IEnumerable<GrabInteractor> setInteractors = transform.GetChild(0).GetComponent<GrabInteractable>().Interactors;
            foreach (GrabInteractor interactor in setInteractors) { interactor.Unselect(); }

            transform.SetPositionAndRotation(targetPuzzle.position, targetPuzzle.rotation);
            targetPuzzle.gameObject.SetActive(false);

            goalManager.AdvanceGoal();

            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

            boxCollider.enabled = false;

            audioSource.Play();

            isSolved = true;
        }
    }
}

