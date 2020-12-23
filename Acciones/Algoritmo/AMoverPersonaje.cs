using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AccionManager
{
    public class AMoverPersonaje : MonoBehaviour
    {
       private Accion refAccion;
        public void SetAMoverPersonaje(Vector3 pos , float time , bool localmente , Accion accion )
        {
           if(accion == null)
            {
                UnityEngine.Debug.Log("Un Error critico Ocurrio en la asignacion a la accion");
                return;
            }

            refAccion = accion;
            refAccion.IsAccionRunning = true;
            refAccion.IsAccionOver = false;

            if (localmente)
                LeanTween.moveLocal(gameObject, pos, time).setDelay(0.1f).setOnComplete(FinalizarMoverPersonaje);
            else
                LeanTween.move(gameObject, pos, time).setDelay(0.1f).setOnComplete(FinalizarMoverPersonaje);

        }

        // Update is called once per frame
        private void FinalizarMoverPersonaje()
        {
            refAccion.IsAccionOver = true;
            refAccion.IsAccionRunning = false;
            Destroy(this);
        }
    }
}