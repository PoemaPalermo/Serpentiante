using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text[] puntajesEasy;
    public Text[] puntajesNormal;
    public Text[] puntajesHard;
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i<GameManager.Instance.data.mejoresPuntajeEasy.Count; i++)
        {
            puntajesEasy[i].text = GameManager.Instance.data.mejoresPuntajeEasy[i].ToString();
        }
        for(int i = 0; i<GameManager.Instance.data.mejoresPuntajeNormal.Count; i++)
        {
            puntajesNormal[i].text = GameManager.Instance.data.mejoresPuntajeNormal[i].ToString();
        }
        for(int i = 0; i<GameManager.Instance.data.mejoresPuntajeHard.Count; i++)
        {
            puntajesHard[i].text = GameManager.Instance.data.mejoresPuntajeHard[i].ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
