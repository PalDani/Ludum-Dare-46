using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceCarTask : Task
{
    public ParticleSystem[] carSmoke;
    public AudioSource carSound;

    public override void Execute()
    {
        foreach (var ps in carSmoke)
        {
            ps.gameObject.SetActive(true);
            ps.Play();
            carSound.Play();
        }
        base.Execute();

        StartCoroutine(ResetSmoke());
    }

    private IEnumerator ResetSmoke()
    {
        yield return new WaitForSeconds(2);
        carSound.Stop();
        foreach (var ps in carSmoke)
        {
            ps.gameObject.SetActive(false);
        }
    }
}
