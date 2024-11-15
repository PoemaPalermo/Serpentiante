using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuDificultad : MonoBehaviour
{
    public GameObject panel;
    private void Start()
    {
        panel.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detectar clic izquierdo
        {
            // Verificar si el clic fue en UI
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Revisar si el clic está específicamente sobre el panel o sus hijos
                if (IsClickInsidePanel())
                {
                    return; // No ocultar si el clic fue dentro del panel
                }
            }

            // Ocultar el panel si el clic fue fuera
            panel.SetActive(false);
        }
    }

    private bool IsClickInsidePanel()
    {
        // Crear un PointerEventData en la posición actual del mouse
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // Hacer un raycast para detectar los objetos de UI bajo el cursor
        var raycastResults = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResults);

        // Revisar si el panel está entre los objetos clicados
        foreach (var result in raycastResults)
        {
            if (result.gameObject == panel || result.gameObject.transform.IsChildOf(panel.transform))
            {
                return true; // Clic dentro del panel o sus hijos
            }
        }

        return false; // Clic fuera del panel
    }
    public void ElegirDificultad()
    {
        panel.SetActive(true);
    }
}
