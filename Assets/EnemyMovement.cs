using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float flyOutDistance = 100f;
    public bool hasFinishedFlyout = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyObject>().onEnemyhit += DamageReact;
        transform.rotation = Quaternion.LookRotation(Vector3.forward);
        transform.position = Vector3.zero + RandomPositions.access.GetRandomPosition();

        hasFinishedFlyout = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFinishedFlyout)
        {
            transform.position += ((Vector3.forward * 25f) * Time.deltaTime);
            if (transform.position.z > 300f)
                hasFinishedFlyout = true;
            return;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Camera.main.transform.position - transform.position), Time.deltaTime * 5f);
        transform.position += ((Vector3.forward * -15f) * Time.deltaTime);
        
    }
    private void DamageReact()
    {
        transform.rotation = Quaternion.LookRotation((Camera.main.transform.position - transform.position) + (Random.onUnitSphere*30f));
    }
}
