using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Camera cam;
    public LayerMask MovementMask;
    PlayerMotor motor;

    private void Start()
    {
        if (!cam) cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, MovementMask))
            {
                print("We hit " + hit.collider.name + " " + hit.point);
                //Move to hit location
                motor.Move(hit.point);
                //Stop focusing
            }
        }
    }
}
