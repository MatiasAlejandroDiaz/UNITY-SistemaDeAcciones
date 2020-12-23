using UnityEngine;

namespace AccionManager
{
    [System.Serializable]
    public class Accion
    {
        /*Acciones
          0) VibrarPersonaje
          1) PlayAnimacionPersonaje
          2) CrearPersonaje
          3) MoverPersonaje
          4) SacarPersonaje
          5) CambiarImagenPersonaje
          6) 
        */
        // Variables Compartidas
        public string Target;
        public float Time = 1f;
        public bool IsAccionRunning = false;
        public bool IsAccionOver = false;
        public bool EsperarATerminar = true;

        //Variables Vibrar
        public float amount = 2f;
        // Variables Play Animacion
        public string nombreAnimacion = "";
        public bool esperar = false;
        // Variables Crear Personaje
        public Vector2 posicionPersonaje;
        public Vector2 escalaPersonaje;
        // Variables Mover Personaje
        public bool localmente = false;
        // Sacar Personaje


        //CONSTRUCTORES DEPENDIENDO LA ACCION

        //0) CONSTRUCTOR VIBRAR
        public Accion(string Target, float amount, float time)
        {
            this.Target = Target;
            this.amount = amount;
            this.Time = time;
        }

        //1) CONSTRUCTOR Play Animacion
        public Accion(string Target, string nombreAnimacion, bool esperar, float tiempo)
        {
            this.nombreAnimacion = nombreAnimacion;
            this.esperar = esperar;
            this.Time = tiempo;
        }

        //2) CONSTRUCTOR Crear Personaje
        public Accion(string Target, Vector2 posicion, Vector2 escala)
        {
            this.Target = Target;
            posicionPersonaje = posicion;
            escalaPersonaje = escala;
        }
        //3) Constructor Mover Personaje
        public Accion(string target , Vector2 posicion , bool localmente , float time)
        {
            this.Target = target;
            posicionPersonaje = posicion;
            this.localmente = localmente;
            this.Time = time;

        }
        //4) Constructor Sacar Personaje
        public Accion(string Target)
        {
            this.Target = Target;
        }

        //TODO
        public void Play(TipoDeAccion tipo)
        {
            if (IsAccionRunning == false && IsAccionOver == false)
            {
                switch (tipo)
                {
                    case TipoDeAccion.Vibrar:
                        StartVibrar();
                        break;
                    case TipoDeAccion.PlayAnimacion:
                        StarPlayAnimacion();
                        break;
                    case TipoDeAccion.CrearPersonaje:
                        StartCrearPersonaje();
                        break;
                    case TipoDeAccion.MoverPersonaje:
                        StartMoverPersonaje();
                        break;
                    case TipoDeAccion.SacarPersonaje:
                        StartSacarPersonaje();
                        break;
                }
            }
        }

        //TODO
        //0) Ejecutar Accion VIBRAR
        private void StartVibrar()
        {
            IsAccionRunning = true;

            GameObject instObject = GameData.PersonajeInstance(Target);

            if (instObject == false) { return; }

            Avibrar referenceComponent = (Avibrar)instObject.AddComponent(typeof(Avibrar));
            referenceComponent.SetAvibrar(instObject.GetComponent<RectTransform>(), amount, Time, this);
            
        }

        //1) Ejecutar Accion Play Animacion
        private void StarPlayAnimacion()
        {
            IsAccionRunning = true;

            GameObject instObject = GameData.PersonajeInstance(Target);

            if (instObject == false) { return; }

            APlayAnimacion referenceComponent = (APlayAnimacion)instObject.AddComponent(typeof(APlayAnimacion));
            int res = referenceComponent.SetAPlayAnimacion(instObject, nombreAnimacion, esperar, Time, this);

            if (res > 0)
            {
                referenceComponent = null;
                return;
            }

            referenceComponent.PlayAnimacion();
            
        }
        // 2) Ejecutar Accion CrearPersonaje
        private void StartCrearPersonaje()
        {
            IsAccionRunning = true;

            GameObject instObject = GameData.PersonajeInstance(Target);

            if (instObject == false) { return; }

            ACrearPersonaje referenceComponent = (ACrearPersonaje)instObject.AddComponent(typeof(ACrearPersonaje));
            referenceComponent.SetCrearPersonaje(posicionPersonaje, escalaPersonaje, this);

        }
        //3) Ejecutar Mover Personaje
        private void StartMoverPersonaje()
        {
            IsAccionRunning = true;
            GameObject instObject = GameData.PersonajeInstance(Target);

            if (instObject == false) { return; }

            AMoverPersonaje referenceComponent = (AMoverPersonaje)instObject.AddComponent(typeof(AMoverPersonaje));
            referenceComponent.SetAMoverPersonaje(posicionPersonaje, Time,localmente, this);
        }
        //4) Ejecutar Sacar Personaje
        private void StartSacarPersonaje()
        {
            GameObject instObject = GameData.PersonajeInstance(Target);

            if (instObject == false) { return; }

            instObject.SetActive(false);
            instObject.transform.position = Vector2.zero;
            instObject.transform.localScale = Vector2.one;

            IsAccionRunning = false;
            IsAccionOver = true;

        }
        public void Reiniciar()
        {
            IsAccionRunning = false;
            IsAccionOver = false;
        }
    }
}
