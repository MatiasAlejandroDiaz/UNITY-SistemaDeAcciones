using UnityEngine;

namespace AccionManager
{
    [System.Serializable]
    public class IAcciones
    {
        public TipoDeAccion tipoDeAccion;
        public Accion accion;
        public IAcciones(TipoDeAccion tipoDeAccion)
        {
            this.tipoDeAccion = tipoDeAccion;

            ////TODO
            switch (tipoDeAccion)
            {
                case TipoDeAccion.Vibrar:
                    this.accion = new Accion(null, 1f, 2f);
                    break;
                case TipoDeAccion.PlayAnimacion:
                    this.accion = new Accion(null, "", true, 2f);
                    break;
                case TipoDeAccion.CrearPersonaje:
                    this.accion = new Accion("", Vector2.zero, Vector2.one);
                    break;
                case TipoDeAccion.MoverPersonaje:
                    accion = new Accion("", Vector2.zero, false, 1f);
                    break;
            }

        }

        public TipoDeAccion GetTipoDeAccion { get => tipoDeAccion; }
        public Accion rAccion { get => accion; set => accion = value; }
    }

}