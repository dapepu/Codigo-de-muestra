using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasCamara : MonoBehaviour
{
    public Canvas imagenMuestra;

    public bool seMuestra;
    public GameObject cam;
    private bool playerIn = false;
    public GameObject camUI;



    void Start()
    {
        seMuestra = false;
        imagenMuestra.enabled = false;
        cam.SetActive(true);
        camUI.SetActive(false);

    }

    void FixedUpdate()
    {
        playerIn = false;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //imagenMuestra.enabled = true;
            playerIn = true;
        }

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && seMuestra == true)
        {
            imagenMuestra.enabled = false;
            seMuestra = false;
            cam.SetActive(true);
            Jugador.playerSpeed = 6f;
            camUI.SetActive(false);


        }
        if (Input.GetKeyDown(KeyCode.E) && seMuestra == false)
        {
            if (playerIn == true)
            {
                imagenMuestra.enabled = true;
                seMuestra = true;
                cam.SetActive(false);
                Jugador.playerSpeed = 0f;
                camUI.SetActive(true);

            }

        }


    }
    public void Esconder()
    {
        imagenMuestra.enabled = false;
        seMuestra = false;
        Time.timeScale = 1.0f;
    }


}







