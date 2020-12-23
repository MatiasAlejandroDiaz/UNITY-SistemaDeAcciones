using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace personaje
{
    public enum TiposDeEstado { Normal , Alegre , Esceptico , Triste , Antipatico , Furioso };
    //TODO
    public enum Personalidad { Timido , Deportista , Gracioso , Egoista , Recto}
    [CreateAssetMenu(fileName = "Personaje",menuName = "Aventura Grafica/Personaje")]
    public class PersonajeData : ScriptableObject
    {
        [Header("Expresiones Faciales")]
        public Sprite normal;
        public Sprite alegre;
        public Sprite esceptico;
        public Sprite triste;
        public Sprite antipatico;
        public Sprite furioso;
        [Space(2)]
        [Header("Caracteristicas")]


        TiposDeEstado tipos = TiposDeEstado.Normal;

        //TODO
        public void OnEnable()
        {
            Debug.Log((int)tipos);
        }
    }
}