using System.Collections.Generic;
using UnityEngine;

namespace AccionManager
{
    [CreateAssetMenu(fileName = "Secuencia De Acciones", menuName = "Aventura Grafica/Secuencia")]
    public class Secuencia : ScriptableObject
    {
        //Variable que contiene la lista de pasos elejida en el inspector
        [SerializeField]
        public List<IAcciones> Pasos = new List<IAcciones>();

        private int accionActualIndex = 0;
        private bool SecuenciaOver = false;
       
        public void SiguienteAccion()
        {
            if (SecuenciaOver)
                return;

            if (accionActualIndex < Pasos.Count)
            {
                if(Pasos[accionActualIndex].accion.IsAccionRunning == true)
                {
                    if(Pasos[accionActualIndex].accion.EsperarATerminar == false)
                    {
                        accionActualIndex++;
                        if (accionActualIndex < Pasos.Count)
                            Pasos[accionActualIndex].accion.Play(Pasos[accionActualIndex].tipoDeAccion);
                    }

                    return;
                }
                else if(Pasos[accionActualIndex].accion.IsAccionOver == false)
                {
                    Pasos[accionActualIndex].accion.Play(Pasos[accionActualIndex].tipoDeAccion);
                }
                else
                {
                    accionActualIndex++;
                    if(accionActualIndex < Pasos.Count)
                        Pasos[accionActualIndex].accion.Play(Pasos[accionActualIndex].tipoDeAccion);
                }
            }
            else
                SecuenciaOver = true;
        }
        public void ReiniciarAcciones ()
        {
            for(int i = 0; i < Pasos.Count; i++)
            {
                Pasos[i].accion.Reiniciar();
            }

            accionActualIndex = 0;
            SecuenciaOver = false;
        }
        public void AddIAccion(TipoDeAccion tAccion)
        {
            Pasos.Add(new IAcciones(tAccion));
        }

        public void removeIAccion(IAcciones selectIAccion)
        {
            if (Pasos.Contains(selectIAccion))
                Pasos.Remove(selectIAccion);

        }
    }
    //TODO
    public enum TipoDeAccion { Vibrar, PlayAnimacion , CrearPersonaje , MoverPersonaje , SacarPersonaje };
}


