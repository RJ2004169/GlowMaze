using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movementSpeed;

    public GameObject camera;

    public GameObject playerObj, lightObj;

    HealthSystem health = new HealthSystem(5.0f);

    public Light light;


    void Start()
    {
        light = lightObj.GetComponent<Light>();

    }


    //Methods
    void Update()
    {
        
        if (health.GetHealth() > 0)
        {
            //Player facing mouse
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitDist = 0.0f;




            if (playerPlane.Raycast(ray, out hitDist))
            {
                Vector3 targetPoint = ray.GetPoint(hitDist);
                Quaternion targetRotaion = Quaternion.LookRotation(targetPoint - transform.position);
                targetRotaion.x = 0;
                targetRotaion.z = 0;
                playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotaion, 7f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
            }
            health.SetHealth(health.GetHealth() - 1 * Time.deltaTime);

            light.range = health.GetHealth() * 2;
        }

    }

    void OnCollisionEnter(Collision col)
    {

        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "FireBug" )
        {
            health.SetHealth(10);
            Destroy(col.gameObject);
        }
    }
}
