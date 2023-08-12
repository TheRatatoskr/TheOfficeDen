using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CameraRayScanner : MonoBehaviour
{
    [SerializeField] private Transform _mainCameraTransform;
    [SerializeField] private float _maxRayDistance = 3f;
    [SerializeField] private RaycastHit hit;

    [SerializeField] private Color _hitColor;
    [SerializeField] private Color _missColor;

    [SerializeField] private SpookManager _spookManager;
        
    void Update()
    {
        Vector3 rayOrigin = _mainCameraTransform.position;
        Vector3 rayDirection = _mainCameraTransform.forward;

        // Create a ray from the calculated origin and direction
        Ray ray = new Ray(rayOrigin, rayDirection);

        // Perform the raycast  
        if (Physics.Raycast(ray, out hit, _maxRayDistance))
            {
            // Debug draw the ray in the scene view (optional)
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);

            // Do something with the hit information, for example:
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if(hit.collider.gameObject.name == "BookCollider")
            {
                _spookManager.AfternoonSpookTriggered();
            }
            if(hit.collider.gameObject.name == "NightBookCollider")
            {
                NightSpook spooker = hit.collider.gameObject.GetComponent<NightSpook>();

                if (spooker != null)
                {
                    spooker.NightSpookTime();
                }
            }
            
        }
        else
        {
            // Debug draw the ray to the maximum distance if nothing is hit (optional)
            Debug.DrawRay(ray.origin, ray.direction * _maxRayDistance, Color.green); 
        }
        
    }
    
}
