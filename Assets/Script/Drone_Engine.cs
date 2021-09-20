using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
public class Drone_Engine : MonoBehaviour, IEngine
{
    #region Variables
    [Header("Engine Properties")]
    [SerializeField] private float maxPower = 4f;

    [Header("Propeller Properties")]
    [SerializeField] private Transform propeller;
    [SerializeField] private float propRotationSpeed = 300f;

    #endregion

    #region Interface Methods
    public void InitEngine()
    {
        throw new System.NotImplementedException();
    }

    public void UpdateEngine(Rigidbody rb, Drone_Input input)
    {
        //Debug.Log("running engine: " + gameObject.name);
        Vector3 engineForce = Vector3.zero;
        engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (input.Throttle * maxPower)) / 4f;
        rb.AddForce(engineForce, ForceMode.Force);
        HandlePropellers();
    }


    void HandlePropellers()
    {
        if (!propeller) { return; }
        propeller.Rotate(Vector3.up * propRotationSpeed);
    }
    #endregion


}
