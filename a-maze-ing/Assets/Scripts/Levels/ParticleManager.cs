using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            particles.Play();
        }
    }
}
