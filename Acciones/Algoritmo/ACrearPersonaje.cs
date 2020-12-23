using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AccionManager {
    public class ACrearPersonaje : MonoBehaviour
    {
        private Accion refAccion;
        private bool todoOk = true;
        private Vector2 posicion;
        private Vector2 escala;

        public void SetCrearPersonaje(Vector2 posicion , Vector2 escala , Accion accion )
        {

            if (accion == null)
            {
                UnityEngine.Debug.Log("Un Error critico Ocurrio en la asignacion a la accion");
                this.todoOk = false;
                return;
            }

            refAccion = accion;
            this.posicion = posicion;
            this.escala = escala;

            if(todoOk == true)
            {
                crearPersonaje();
                FinalizarAccion();
            }
 
        }

        private void crearPersonaje()
        {
            gameObject.transform.localPosition = posicion;
            gameObject.transform.localScale = escala;
            gameObject.SetActive(true);
        }
        private void FinalizarAccion()
        {
            refAccion.IsAccionOver = true;
            refAccion.IsAccionRunning = false;
            Destroy(this);
        }
    }
}