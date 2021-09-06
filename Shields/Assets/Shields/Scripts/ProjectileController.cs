using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] Projectile _Projectile;
    [SerializeField] List<Transform> _ProjectilePoints;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                Transform point = _ProjectilePoints[Random.Range(0, _ProjectilePoints.Count)];
                Projectile projectile = Instantiate(_Projectile, point.position, Quaternion.identity);
                projectile.transform.forward = (hit.point - point.position).normalized;
            }
        }
    }
}
