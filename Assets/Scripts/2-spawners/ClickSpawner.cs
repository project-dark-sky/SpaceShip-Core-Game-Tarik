﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class ClickSpawner : MonoBehaviour
{
    [SerializeField] protected InputAction spawnAction = new InputAction(type: InputActionType.Button);
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;
    public float delayTime = .5f;
    public bool delayEnabled = true;



    void OnEnable()
    {
        spawnAction.Enable();
    }

    void OnDisable()
    {
        spawnAction.Disable();
    }


    private IEnumerator delay()
    {   // co-routines
        enabled = false;
        yield return new WaitForSeconds(delayTime);
        enabled = true;
    }


    protected virtual GameObject spawnObject()
    {
        Debug.Log("Spawning a new object");

        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position;  // span at the containing object position.
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject);

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        if (newObjectMover)
        {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    private void Update()
    {
        // check if the delay is over and there was a click
        if (spawnAction.WasPressedThisFrame())
        {
            spawnObject();
           
            if (delayEnabled)
                StartCoroutine(delay());  // start delay
        }


    }
}
