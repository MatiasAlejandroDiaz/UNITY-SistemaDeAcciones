using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace AccionManager
{
    [OnOpenAsset()]
    public class AssetHandler
    {
        public static bool OpenEditor(int instandeId, int line)
        {
            Secuencia obj = EditorUtility.InstanceIDToObject(instandeId) as Secuencia;

            if(obj != null)
            {
                SecuenciaWindowsEditor.Open(obj);
                return true;
            }
            return false;
        }
    }

    [CustomEditor(typeof(Secuencia))]
    public class SecuenciaEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if(GUILayout.Button("Abrir Editor"))
            {
                AssetHandler.OpenEditor(target.GetInstanceID(),1);
            }          
        }
    }
}