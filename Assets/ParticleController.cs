using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    float frequency = 2;
    float nextEmitTime;
    ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextEmitTime){
            nextEmitTime = Time.time + frequency;
            particleSystem.Play();
        }
    }
}
