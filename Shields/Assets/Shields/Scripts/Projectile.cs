using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float _ProjectileSpeed;
    [SerializeField] GameObject _HitEffect;
    Vector3 _hitNormal;
    Vector3 _hitPos;
    Ray ray;
    RaycastHit hit;
    private void Start()
    {
        Destroy(gameObject, 3);
    }
    void Update()
    {
        Vector3 delta = (transform.forward * _ProjectileSpeed * Time.deltaTime);
        transform.position += delta;
        ray = new Ray(transform.position,transform.forward);
        if(Physics.Raycast(ray,out hit))
        {
            _hitNormal = hit.normal;
            _hitPos = hit.point;
            float distance = (transform.position - hit.point).magnitude;
            if(distance< delta.magnitude)
            {
                Hit(hit.collider);
            }
        }
    }

    void Hit(Collider collider)
    {
        GameObject hit = Instantiate(_HitEffect, _hitPos, Quaternion.identity);
        Shield shield = collider.GetComponentInParent<Shield>();
        if (shield != null)
        {
            shield.HitShield(_hitPos);
        }
        hit.transform.forward = _hitNormal;
        Destroy(gameObject);
    }
}
