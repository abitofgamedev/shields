using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveHeightSetter : MonoBehaviour
{
    Renderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rend.material.SetFloat("_DissolveStartHeight", transform.position.y);
    }
}
