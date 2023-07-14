using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WASDController : MonoBehaviour
{
    [SerializeField] float spd;
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * spd * Time.deltaTime / Mathf.Sqrt(2), Input.GetAxis("Vertical") * spd * Time.deltaTime / Mathf.Sqrt(2));
        }
        else
        {
            transform.position += new Vector3(Input.GetAxis("Horizontal") * spd * Time.deltaTime, Input.GetAxis("Vertical") * spd * Time.deltaTime);
        }

        if(cam.WorldToScreenPoint(transform.position).x < 0)
        {
            transform.position = new Vector3(cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth,0,0)).x,transform.position.y, transform.position.z);
        } else if(cam.WorldToScreenPoint(transform.position).x > cam.pixelWidth)
        {
            transform.position = new Vector3(cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, transform.position.y, transform.position.z);
        }

        if(cam.WorldToScreenPoint(transform.position).y < 0)
        {
            transform.position = new Vector3(transform.position.x, cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0)).y, transform.position.z);
        } else if(cam.WorldToScreenPoint(transform.position).y > cam.pixelHeight)
        {
            transform.position = new Vector3(transform.position.x, cam.ScreenToWorldPoint(new Vector3(0, 0, 0)).y, transform.position.z);
        }
    }
}
