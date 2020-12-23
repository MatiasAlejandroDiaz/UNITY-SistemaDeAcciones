using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace AccionManager
{
    public class SecuenciaWindowsEditor : EditorWindow
    {
        public Secuencia refSecuencia = null;
        public IAcciones selectIAccion = null;
        TipoDeAccion tAccion = TipoDeAccion.Vibrar;

        public static void Open(Secuencia Secuencia)
        {
            SecuenciaWindowsEditor ventana = GetWindow<SecuenciaWindowsEditor>("Secuencia Editor");          
            ventana.refSecuencia = Secuencia;
            ventana.maxSize = new Vector2(550, 350);
        }


        private void OnGUI()
        {

            
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true), GUILayout.Width(200));

            EditorGUILayout.BeginVertical("box");
            if (GUILayout.Button("Guardar"))
                AssetDatabase.SaveAssets();
            EditorGUILayout.EndVertical();

            foreach (IAcciones IAcc in refSecuencia.Pasos)
            {
                if(GUILayout.Button(IAcc.tipoDeAccion.ToString()))
                {
                    selectIAccion = IAcc;
                    GUI.FocusControl(null);
                }              
            }
            EditorGUILayout.EndVertical();
           
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
            //TODO
            if (selectIAccion != null)
            {
                switch(selectIAccion.tipoDeAccion)
                {
                    case TipoDeAccion.Vibrar:
                        selectIAccion.accion.Target = EditorGUILayout.TextField(new GUIContent("Objetivo"),selectIAccion.accion.Target);
                        selectIAccion.accion.amount = EditorGUILayout.FloatField(new GUIContent("Fuerza"),selectIAccion.accion.amount);
                        selectIAccion.accion.Time = EditorGUILayout.FloatField(new GUIContent("Tiempo de Efecto"),selectIAccion.accion.Time);
                        selectIAccion.accion.EsperarATerminar = EditorGUILayout.Toggle(new GUIContent("Esperar A terminar Accion?"), selectIAccion.accion.EsperarATerminar);
                        break;
                    case TipoDeAccion.PlayAnimacion:
                        selectIAccion.accion.Target = EditorGUILayout.TextField(new GUIContent("Objetivo"),selectIAccion.accion.Target);
                        selectIAccion.accion.nombreAnimacion = EditorGUILayout.TextField(new GUIContent("Nombre De Animacion"), selectIAccion.accion.nombreAnimacion);
                        selectIAccion.accion.esperar = EditorGUILayout.Toggle(new GUIContent("Esperar A Terminar Animacion?","Si se Marca false sale de la accion respecto al tiempo de lo contrario la accion termina cuando la animacion lo hace."), selectIAccion.accion.esperar);
                        selectIAccion.accion.Time = EditorGUILayout.FloatField(new GUIContent("Tiempo de Salida de Accion"), selectIAccion.accion.Time);
                        selectIAccion.accion.EsperarATerminar = EditorGUILayout.Toggle(new GUIContent("Esperar A terminar Accion?"), selectIAccion.accion.EsperarATerminar);
                        break;
                    case TipoDeAccion.CrearPersonaje:
                        selectIAccion.accion.Target = EditorGUILayout.TextField(new GUIContent("Objetivo"), selectIAccion.accion.Target);
                        selectIAccion.accion.posicionPersonaje = EditorGUILayout.Vector2Field(new GUIContent("Posicion Inicial"), selectIAccion.accion.posicionPersonaje);
                        selectIAccion.accion.escalaPersonaje = EditorGUILayout.Vector2Field(new GUIContent("Escala Inicial"), selectIAccion.accion.escalaPersonaje);
                        break;
                    case TipoDeAccion.MoverPersonaje:
                        selectIAccion.accion.Target = EditorGUILayout.TextField(new GUIContent("Objetivo"), selectIAccion.accion.Target);
                        selectIAccion.accion.posicionPersonaje = EditorGUILayout.Vector2Field(new GUIContent("Posicion Inicial"), selectIAccion.accion.posicionPersonaje);
                        selectIAccion.accion.localmente = EditorGUILayout.Toggle(new GUIContent("Mover Local", "Mover el Personaje respecto de su Parent."), selectIAccion.accion.localmente);
                        selectIAccion.accion.Time = EditorGUILayout.FloatField(new GUIContent("Tiempo en moverse"), selectIAccion.accion.Time);
                        selectIAccion.accion.EsperarATerminar = EditorGUILayout.Toggle(new GUIContent("Esperar A terminar Accion?"), selectIAccion.accion.EsperarATerminar);
                        break;
                    case TipoDeAccion.SacarPersonaje:
                        selectIAccion.accion.Target = EditorGUILayout.TextField(new GUIContent("Objetivo"), selectIAccion.accion.Target);
                        break;
                }
            }
            else
                EditorGUILayout.LabelField("Seleccione una Accion.");
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Añadir Accion", GUILayout.ExpandWidth(false), GUILayout.Width(100)))
            {
                refSecuencia.AddIAccion(tAccion);
            }
            tAccion = (TipoDeAccion)EditorGUILayout.EnumPopup(tAccion);
            if (GUILayout.Button("Remover Accion ", GUILayout.ExpandWidth(false), GUILayout.Width(100)))
            {
                refSecuencia.removeIAccion(selectIAccion);

                if (refSecuencia.Pasos.Count > 0)
                {
                    selectIAccion = refSecuencia.Pasos[0];
                }
                else
                    selectIAccion = null;
            }           
            EditorGUILayout.EndHorizontal();

            

            if ( EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(refSecuencia);
                
            }
           
        }

    }
}