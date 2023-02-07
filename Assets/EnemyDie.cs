using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyObject>().onEnemyDie += Explode;

    }

    // Update is called once per frame
    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
    }
}
