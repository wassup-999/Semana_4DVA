using Unity.Cinemachine;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
    public CinemachineCamera camA;
    public CinemachineCamera camB;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camA.Priority = 10;
            camB.Priority = 20;
        }  
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camA.Priority = 20;
            camB.Priority = 10;
        }  
       
    }
}
