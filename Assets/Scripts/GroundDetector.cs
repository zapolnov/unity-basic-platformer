using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    int collisions;
    public bool IsAtGround => collisions != 0;

    int platformLayer;
    int enemyLayer;
    Transform characterTransform;

    void Start()
    {
        platformLayer = LayerMask.NameToLayer("Platform");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        characterTransform = transform.parent;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != enemyLayer)
            collisions++;

        if (other.gameObject.layer == platformLayer)
            characterTransform.SetParent(other.transform);

        if (other.gameObject.layer == enemyLayer)
            other.transform.GetComponent<Enemy>().Kill();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != enemyLayer)
            collisions--;

        if (other.gameObject.layer == platformLayer && other.transform == characterTransform.parent)
            characterTransform.SetParent(null);
    }
}
