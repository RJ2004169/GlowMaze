using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    //Variables
    public Transform m_Target;
    public float m_Distance = 25f;
    public float m_height = 35f, m_angle = -90f, m_smoothSpeed = 0.5f;

    private Vector3 refVelocity;



    //Methods

    void Start()
    {
        HandleCamera();
    }

    void Update()
    {
        HandleCamera();

        //transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);

    }
    protected virtual void HandleCamera()
    {
        if(!m_Target)
        {
            return;
        }

        ///World position vector
        Vector3 worldPosition = (Vector3.forward * -m_Distance) + (Vector3.up * m_height);

        //Build rotated vector
        Vector3 rotatedVector = Quaternion.AngleAxis(m_angle, Vector3.up) * worldPosition;

        //Move our position

        Vector3 flatTargetPosition = m_Target.position;
        flatTargetPosition.y = 0f;
        Vector3 finalPosition = flatTargetPosition + rotatedVector;

        transform.position = Vector3.SmoothDamp(transform.position, finalPosition, ref refVelocity, m_smoothSpeed);
        transform.LookAt(flatTargetPosition);

    }

}
