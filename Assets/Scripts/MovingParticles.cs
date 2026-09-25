using UnityEngine;

[RequireComponent(typeof(MovingParticles))]
public class MovingParticles : MonoBehaviour
{
    [SerializeField] private bool ignoreX;
    [SerializeField] private bool ignoreY = true;
    [SerializeField] private bool ignoreZ;
    private Vector3 lastPos;

    private ParticleSystem particles;

    void Awake()
    {
        particles = GetComponent<ParticleSystem>();
        lastPos = transform.position;
    }

    void LateUpdate()
    {
        Vector3 currentPos = transform.position;
        if((!ignoreX && currentPos.x != lastPos.x) || (!ignoreY && currentPos.y != lastPos.y) || (!ignoreZ && currentPos.z != lastPos.z))
        {
            if(!particles.isPlaying) particles.Play();
        }
        else if(particles.isPlaying) particles.Stop();

        lastPos = transform.position;
    }
}