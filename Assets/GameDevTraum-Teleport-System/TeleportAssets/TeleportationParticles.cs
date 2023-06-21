using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationParticles : MonoBehaviour
{
    public ParticleSystem particles;
    ParticleSystem.EmissionModule particlesEmission;
    public float particleMaxRate;
    public float changeSpeed;

    float particleRate;
    bool rising;

    void OnEnable()
    {

        particlesEmission = particles.emission;
        particleRate = 0;
        rising = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rising)
        {
            particleRate += Time.deltaTime*changeSpeed;
            if (particleRate > particleMaxRate)
            {
                rising = false;
            }
        }
        else
        {
            particleRate -= Time.deltaTime * changeSpeed;
        }
        if (particleRate > 0)
        {
            particlesEmission.rateOverTime = particleRate;
        }
        else
        {
            particles.Stop();
        }
    }
}
