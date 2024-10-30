using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimCrosshair : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] LayerMask shootableLayers;
    [SerializeField] Transform gun;
    [SerializeField] Image crosshair;
    [SerializeField] Transform barrelEnd;

    [SerializeField] Color colorValidTarget;
    [SerializeField] Color colorNoValidTarget;



    // Update is called once per frame
    void Update()
    {
        Aim();
    }

    void Aim()
    {
        RaycastHit hit;
        Vector3 start = cam.transform.position;
        Vector3 forward = cam.transform.forward;

        if (Physics.Raycast(start, forward, out hit, 1000.0f, shootableLayers))
        {
            barrelEnd.LookAt(hit.point);
            crosshair.color = colorValidTarget;
            return;
        }

        crosshair.color = colorNoValidTarget;
        //gun.forward = forward;
        barrelEnd.forward = forward;
    }
}
