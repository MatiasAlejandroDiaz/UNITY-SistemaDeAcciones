using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AccionManager
{
    public class GameData : MonoBehaviour
    {
        [SerializeField]
        static public SceneData DatosDeScena;

        public Image fondoComponent;
        public GameObject CanvasDialogo;
        public GameObject CanvasPersonaje;


        static List<GameObject> PersonajesInstanciados;

        public SceneData inspectorDatos;

        private void OnEnable()
        {
            DatosDeScena = inspectorDatos;    
        }

        public void Start()
        {
            PersonajesInstanciados = new List<GameObject>();

            if (fondoComponent == null)
                fondoComponent =(Image)Instantiate(new GameObject("Empty"), Vector3.zero, Quaternion.identity).AddComponent(typeof(Image));

            if(inspectorDatos != null)
            {
                for(int i = 0; i < inspectorDatos.countCharacters;i++)
                {
                    PersonajesInstanciados.Add(Instantiate( inspectorDatos.listaCharacters[i], Vector3.zero, Quaternion.identity,CanvasPersonaje.transform));
                }
            }

            foreach(GameObject p in PersonajesInstanciados)
            {
                p.SetActive(false);
            }
        }
        static public GameObject PersonajeInstance(string indentificador)
        {
            if (DatosDeScena != null && DatosDeScena.GetIndexOfCharacter(indentificador) != -1 && DatosDeScena.GetIndexOfCharacter(indentificador) < PersonajesInstanciados.Count)
            {
                GameObject obj = PersonajesInstanciados[DatosDeScena.GetIndexOfCharacter(indentificador)];

                return obj != null ? (obj) : null;
            }
            else
                return null;
        }

        static public GameObject PersonajePrefab(string indentificador)
        {
            if (DatosDeScena != null)
            {
                GameObject obj = DatosDeScena.GetCharacter(indentificador);

                return obj != null ? (obj) : null;
            }
            else
                return null;
        }

        static public Sprite Fondo( string identificador)
        {
            if (DatosDeScena != null)
            {
                Sprite obj = DatosDeScena.GetFondo(identificador);

                return obj != null ? obj : null;
            }
            else
                return null;
        }

        static public string Dialogo(int identificador)
        {
            if (DatosDeScena != null)
            {
                return DatosDeScena.GetDialogo(identificador);
            }
            else
                return string.Empty;
        }
    }
}