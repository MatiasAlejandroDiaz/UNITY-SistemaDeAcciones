using System.Diagnostics;
using UnityEngine;

namespace AccionManager
{
    public class Avibrar : MonoBehaviour
    {
        private Vector3 prePosition;
        private RectTransform target;
        private float amount = 2f;
        private float time = 1f;
        private Stopwatch reloj;
        private bool todoOk = false;
        private Accion refAccion = null;

        public void SetAvibrar(RectTransform rTarget , float rAmount , float rTime , Accion refAccion)
        {

            if (rTarget == null || refAccion == null)
            {
                UnityEngine.Debug.Log("Un Error critico Ocurrio en la asignacion a la accion.");
                this.todoOk = false;
                return;
            }

            this.target = rTarget;
            this.amount = rAmount;
            this.time = rTime;
            this.prePosition = rTarget.position;
            this.refAccion = refAccion;
            this.refAccion.IsAccionRunning = true;
            reloj = new Stopwatch();
            this.todoOk = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (todoOk == true) 
            {
                if (reloj.IsRunning == false)
                    reloj.Start();

                if (reloj.Elapsed.Seconds <= time)
                {
                    target.position = new Vector3(prePosition.x,prePosition.y,0) + (Random.insideUnitSphere * amount);
                }
                else
                {
                    target.position = prePosition;
                    reloj.Stop();
                    reloj.Reset();
                    refAccion.IsAccionOver = true;
                    refAccion.IsAccionRunning = false;
                    Destroy(this);
                }
            }
        }

        
    }
}