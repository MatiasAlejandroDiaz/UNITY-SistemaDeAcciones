using System.Diagnostics;
using UnityEngine;

namespace AccionManager
{
    public class APlayAnimacion : MonoBehaviour
    {
        private Animation anim;
        private string nombreAnim = "";
        private float tiempoDeAnim = 0;
        private bool esperarAnim = true;
        private bool todoOk = false;
        private Accion refAccion = null;
        private Stopwatch reloj;

        // Start is called before the first frame update
        private void Start()
        {
            reloj = new Stopwatch();
        }
        public int SetAPlayAnimacion(GameObject target,string nombreDeAnim,bool esperarAnim , float tiempo, Accion refAccion)
        {
            anim = target.GetComponent<Animation>();

            nombreAnim = nombreDeAnim;
            this.esperarAnim = esperarAnim;
            reloj = new Stopwatch();

            this.refAccion = refAccion;

            if (anim == null || refAccion == null)
            {
                todoOk = false;
                Destroy(this, 0.1f);
                refAccion.IsAccionOver = true;
                return 1;
            }
            AnimationClip animClip = anim.GetClip(nombreAnim);
            if (animClip == null)
            {
                todoOk = false;
                Destroy(this, 0.1f);
                refAccion.IsAccionOver = true;
                return 1;
            }

            if (esperarAnim == true)
                tiempoDeAnim = animClip.length;
            else
                tiempoDeAnim = tiempo;

            return 0;
        }

        public void PlayAnimacion()
        {
            if (todoOk == false)
            {
                reloj.Stop();
                reloj.Reset();
                anim.Stop();
                refAccion.IsAccionOver = true;
                Destroy(this);
                return;
            }

            reloj.Start();
            anim.CrossFade(nombreAnim, 0.5f);
        
        }

        private void Update()
        {
            if(reloj.IsRunning && reloj.Elapsed.Seconds > tiempoDeAnim)
            {
                reloj.Stop();
                reloj.Reset();
                anim.Stop();
                refAccion.IsAccionOver = true;
                Destroy(this);
            }
        }
    }
}