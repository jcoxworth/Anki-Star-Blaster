using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageFlash : MonoBehaviour
{
    public float flashTime = 0.3f;
    public SkinnedMeshRenderer _renderer;
    public Material flashMaterial;
    public Color[] originalColors;
    void Start()
    {
        originalColors = new Color[_renderer.materials.Length];
        for (int i = 0; i < _renderer.materials.Length; i++)
        {
            originalColors[i]= _renderer.materials[i].GetColor("_Emission"); 
        }
        GetComponent<EnemyObject>().onEnemyhit += FlashRed;
    }
    void FlashRed()
    {
        for (int i = 0; i < _renderer.materials.Length; i++)
        {
            _renderer.materials[i].SetColor("_Emission", Color.white);// = originalColors[i];

            //originalColors[i] = Color.white;
        }
        Invoke("ResetColor", flashTime);
    }
    void ResetColor()
    {
        for (int i = 0; i < _renderer.materials.Length; i++)
        {
            _renderer.materials[i].SetColor("_Emission", originalColors[i]);// = originalColors[i];

            _renderer.materials[i].color= originalColors[i];
        }
    }
}
