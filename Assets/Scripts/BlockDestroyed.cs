using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyed : MonoBehaviour {

    [SerializeField] ParticleSystem blockDestroyParticles;

    public bool blockDestroyed;

    void Start()
    {
        blockDestroyed = false;
    }

    private void Update()
    {
        if (blockDestroyed)
        {
            blockDestroyParticles.Play();
            blockDestroyed = false;
        }
    }
}
