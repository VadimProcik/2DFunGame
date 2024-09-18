using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{

    bool isSelected;
    public LayerMask resourceLayer;
    public float collectDistance;
    Resource currentResource;
    public float timeBetweenCollect;
    float nextCollectTime;
    public int collectAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            transform.position = mousePos;
        } else 
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if (col != null && currentResource == null)
            {
                currentResource = col.GetComponent<Resource>();
            }else{
                currentResource = null;
            }

            if(currentResource != null)
            {
                if (Time.time > nextCollectTime)
                {
                    nextCollectTime = Time.time + timeBetweenCollect;
                    currentResource.resourceAmount -= collectAmount;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        isSelected = true;
    }

    private void OnMouseUp()
    {
        isSelected = false;
    }
}
