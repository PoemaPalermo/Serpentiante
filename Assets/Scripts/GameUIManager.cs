using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text txtTDificultad;
    public Text txtDificultad;
    public Text txtTPuntajeActual;
    public Text txtPuntajeActual;
    public Text txtTMejorPuntaje;
    public Text txtMejorPuntaje;
    public Text txtAvisoMejorPuntaje;
    int ultimoPunto;
    // Start is called before the first frame update
    void Start()
    {
        txtAvisoMejorPuntaje.text = "";
        PasarAUI(txtTPuntajeActual, "Score:", txtPuntajeActual, "", 0);
        if (GameManager.Instance.dificultad == "e")
        {
            PasarAUI(txtTDificultad, "Dificultad:", txtDificultad, "Easy", 0);
            PasarAUI(txtTMejorPuntaje, "Best score:", txtMejorPuntaje, "", GameManager.Instance.data.mejoresPuntajeEasy[0]);
        }
        else if (GameManager.Instance.dificultad == "n")
        {
            PasarAUI(txtTDificultad, "Dificultad:", txtDificultad, "Normal", 0);
            PasarAUI(txtTMejorPuntaje, "Best score:", txtMejorPuntaje, "", GameManager.Instance.data.mejoresPuntajeNormal[0]);
        }
        else if (GameManager.Instance.dificultad == "h")
        {
            PasarAUI(txtTDificultad, "Dificultad:", txtDificultad, "Hard", 0);
            PasarAUI(txtTMejorPuntaje, "Best score:", txtMejorPuntaje, "", GameManager.Instance.data.mejoresPuntajeHard[0]);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.puntos != ultimoPunto)
        {
            txtPuntajeActual.text = GameManager.Instance.puntos.ToString();
            ultimoPunto = GameManager.Instance.puntos;
        } 
        if (GameManager.Instance.dificultad == "e")
        {
            if(GameManager.Instance.data.mejoresPuntajeEasy[4] <= GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "Estás en el top 5";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ",0);
            }
            else if(GameManager.Instance.data.mejoresPuntajeEasy[0] < GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "SOS EL NUEVO MEJOR PUNTAJE";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ",0);
            }
            else if(txtAvisoMejorPuntaje.text != "")
            {
                txtAvisoMejorPuntaje.text = "";
            }
        }
        else if (GameManager.Instance.dificultad == "n")
        {
            if (GameManager.Instance.data.mejoresPuntajeNormal[4] <= GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "Estás en el top 5";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ", 0);
            }
            else if (GameManager.Instance.data.mejoresPuntajeNormal[0] < GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "SOS EL NUEVO MEJOR PUNTAJE";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ", 0);
            }
            else if (txtAvisoMejorPuntaje.text != "")
            {
                txtAvisoMejorPuntaje.text = "";
            }
        }
        else if (GameManager.Instance.dificultad == "h")
        {
            if (GameManager.Instance.data.mejoresPuntajeHard[4] <= GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "Estás en el top 5";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ", 0);
            }
            else if (GameManager.Instance.data.mejoresPuntajeHard[0] < GameManager.Instance.puntos)
            {
                txtAvisoMejorPuntaje.text = "SOS EL NUEVO MEJOR PUNTAJE";
                PasarAUI(txtTMejorPuntaje, " ", txtMejorPuntaje, " ", 0);
            }
            else if (txtAvisoMejorPuntaje.text != "")
            {
                txtAvisoMejorPuntaje.text = "";
            }
        }
        
    }

    public void PasarAUI(Text txtTitulo, string strTitulo, Text txtValor, string strValor, int intValor)
    {
        txtTitulo.text = strTitulo;
        if(strValor == "")
        {
            strValor = intValor.ToString();
        }
        txtValor.text = strValor;
    }
}
