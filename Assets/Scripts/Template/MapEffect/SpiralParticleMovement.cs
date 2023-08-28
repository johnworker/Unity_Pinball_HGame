using System.Collections;
using UnityEngine;

public class SpiralParticleMovement : MonoBehaviour
{
    [Header("粒子系統")]
    public ParticleSystem particleSystem;

    public int particleCount = 500; // 要生成的粒子數量
    public float rotationSpeed = 3f;
    public float cylinderRadius = 10000f;
    public float cylinderHeight = 10f;
    public float heightOffset = 0f;

    private ParticleSystem.Particle[] particles;

    private void Start()
    {
        particleSystem.Emit(particleCount);
        particles = new ParticleSystem.Particle[particleCount];
        InitializeParticlePositions();
    }

    private void InitializeParticlePositions()
    {
        for (int i = 0; i < particleCount; i++)
        {
            float randomAngle = Random.Range(0f, 360f);
            float randomHeight = Random.Range(0f, cylinderHeight);

            float xPos = Mathf.Cos(randomAngle) * cylinderRadius;
            float yPos = heightOffset + randomHeight;
            float zPos = Mathf.Sin(randomAngle) * cylinderRadius;

            Vector3 position = new Vector3(xPos, yPos, zPos);
            particles[i].position = position;
        }

        particleSystem.SetParticles(particles, particleCount);
    }

    private void Update()
    {
        RotateParticles();
    }

    private void RotateParticles()
    {
        int particleCount = particleSystem.GetParticles(particles);

        for (int i = 0; i < particleCount; i++)
        {
            float angle = rotationSpeed * Time.time + i * 0.1f;
            particles[i].position = Quaternion.Euler(0f, angle, 0f) * particles[i].position;
        }

        particleSystem.SetParticles(particles, particleCount);
    }
}