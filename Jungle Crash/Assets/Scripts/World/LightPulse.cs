using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightPulse : MonoBehaviour
{
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;
    [SerializeField] private float pulseFrequency;

    private Light2D light2D;
    private float elapsedTime;

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    private void Update()
    {
        light2D.intensity = minIntensity + Mathf.PingPong(elapsedTime / pulseFrequency, maxIntensity);
        elapsedTime += Time.deltaTime;
    }
}
