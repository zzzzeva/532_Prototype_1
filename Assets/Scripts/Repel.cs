using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repel : MonoBehaviour
{
    public Material newMaterial;

    private Material currentMaterial;
    private Renderer thisRenderer;

    public Transform thisObject;
    public GameObject otherObject;   // The other GameObject to maintain distance from
    public float minXDistance = 2f;  // Minimum distance allowed on the X axis
    public float minZDistance = 2f;  // Minimum distance allowed on the Z axis

    private Vector3 lastValidPosition;

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        currentMaterial = thisRenderer.material;
        lastValidPosition = thisObject.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        float xDistance = Mathf.Abs(thisObject.position.x - otherObject.transform.position.x);
        float zDistance = Mathf.Abs(thisObject.position.z - otherObject.transform.position.z);

        Debug.Log(xDistance + " and " + zDistance);

        if (xDistance < minXDistance && zDistance < minZDistance)
        {
            // Revert to the last valid position if too close on either the X or Z axis
            thisObject.parent.position = lastValidPosition;

            if (thisRenderer != null && newMaterial != null)
            {
                Debug.Log("changing");
                //currentMaterial = thisRenderer.material;
                thisRenderer.material = newMaterial;
            }
            Debug.Log("Collider");
            GetComponent<AudioSource>().Play();
        }
        else
        {
            // Update the last valid position
            lastValidPosition = thisObject.parent.position;
            thisRenderer.material = currentMaterial;
        }

    }
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject == number1)
        {
            
            if (thisRenderer != null && newMaterial != null)
            {
                Debug.Log("changing");
                currentMaterial = thisRenderer.material;
                thisRenderer.material = newMaterial;
            }
            Debug.Log("Collider");
            number1Collider.GetComponent<BoxCollider>().enabled = true;
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        thisRenderer.material = currentMaterial;
        number1.GetComponent<BoxCollider>().enabled = false;
    }*/


}
