using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    public CharacterController jugador;

    Vector3 posicionSuelo;
    Vector3 ultimaPosicionSuelo;
    string groundName;
    string lastGroundName;


    Quaternion actualRot;
    Quaternion ultimoRot;

    public Vector3 originOffset;
    public float factorDivision = 4.2f;

    // Start is called before the first frame update
    void Start()
    {
        jugador = this.GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (jugador.isGrounded)
        {
            RaycastHit hit;

            //variable de lo que golpea el Raycast
            if (Physics.SphereCast(transform.position + originOffset, jugador.radius / factorDivision, -transform.up, out hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                posicionSuelo = groundedIn.transform.position;

                actualRot = groundedIn.transform.rotation;
                //mover el personaje con la plataforma
                if (posicionSuelo != ultimaPosicionSuelo && groundName == lastGroundName)
                {
                    this.transform.position += posicionSuelo - ultimaPosicionSuelo;

                }
                // rotar el personaje con la plataforma
                if (actualRot != ultimoRot && groundName == lastGroundName)
                {
                    //variable nueva que servira para adaptar la rotacion actual contra la anterior
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - ultimoRot.eulerAngles);
                    //jugador rotara con la plataforma
                    this.transform.RotateAround(groundedIn.transform.position, Vector3.up, newRot.y);
                }
                lastGroundName = groundName;
                ultimaPosicionSuelo = posicionSuelo;
                ultimoRot = actualRot;
            }


        }
        else if (!jugador.isGrounded)
        {
            lastGroundName = null;
            ultimaPosicionSuelo = Vector3.zero;
            ultimoRot = Quaternion.Euler(0, 0, 0);
        }

    }
    //creamos un gizmos desde el cual dispararemos el raycast 
    private void OnDrawGizmos()
    {
        jugador = this.GetComponent<CharacterController>();

        Gizmos.DrawWireSphere(transform.position + originOffset, jugador.radius / factorDivision);
    }
}
