using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageFlash : MonoBehaviour
{
    public UnityEngine.UI.Image damageLayer;
    private float damageOpacity;
    // Start is called before the first frame update
    void Start()
    {
        damageOpacity = 0f;
        GetComponent<LevelManager>().onPlayerHit += Flash;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageOpacity > 0f)
            damageOpacity -= (Time.deltaTime * 2f);
        damageLayer.color = new Color(1f, 0f, 0f, damageOpacity);
    }
    private void Flash()
    {
        damageOpacity = 0.5f;
    }
}
