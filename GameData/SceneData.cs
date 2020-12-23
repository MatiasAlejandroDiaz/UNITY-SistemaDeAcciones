using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AccionManager;
using System;

[CreateAssetMenu(fileName = "Escena", menuName = "Aventura Grafica/Datos De Escena")]
public class SceneData : ScriptableObject
{

    //Fondos Variables
    public List<Sprite> listaSprites = new List<Sprite>();
    public List<string> listaNombresSprites = new List<string>();
    public int countFondos = 0;
    //character Variables
    public List<GameObject> listaCharacters = new List<GameObject>();
    public List<string> listaNombresCharacters = new List<string>();
    public int countCharacters = 0;
    //dialogo variables
    public List<int> listaIdDialogos = new List<int>();
    public List<string> listaDialogos = new List<string>();
    public int countDialogos = 0;

    public void incrementFondo()
    {
        countFondos++;
        Debug.Log(countFondos);
    }

    public GameObject GetCharacter( string key)
    {
        if (listaNombresCharacters.Contains(key))
        {
            return listaCharacters[listaNombresCharacters.IndexOf(key)];
        }
        else
            return null;
    }

    public int GetIndexOfCharacter( string key )
    {
        if (listaNombresCharacters.Contains(key))
        {
            return listaNombresCharacters.IndexOf(key);
        }
        else
            return -1;
    }

    public Sprite GetFondo(string key)
    {
        if (listaNombresSprites.Contains(key))
        {
            return listaSprites[listaNombresSprites.IndexOf(key)];
        }
        else
            return null;
    }

    public string GetDialogo(int key)
    {
        if (listaIdDialogos.Contains(key))
        {
            return listaDialogos[listaIdDialogos.IndexOf(key)];
        }
        else
            return string.Empty;
    }
}
