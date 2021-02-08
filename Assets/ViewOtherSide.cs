using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using RenderPipeline = UnityEngine.Rendering.RenderPipeline;

//[ExecuteInEditMode]
public class ViewOtherSide : MonoBehaviour
{
    public Camera portalCamera;
    public Transform pairPortal;
    public float offset = 0.1f;

    private void OnEnable()
    {
        RenderPipelineManager.beginCameraRendering += UpdateCamera;
    }

    private void OnDisable()
    {
        RenderPipelineManager.beginCameraRendering -= UpdateCamera;
    }

    void UpdateCamera(ScriptableRenderContext context, Camera camera)
    {
        if ((camera.cameraType == CameraType.Game || camera.cameraType == CameraType.SceneView) &&
            camera.tag != "Portal Camera")
        {
            portalCamera.projectionMatrix = camera.projectionMatrix; // Match matrices

            var relativePosition = transform.InverseTransformPoint(camera.transform.position);
            relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
            portalCamera.transform.position = pairPortal.TransformPoint(relativePosition);

            var relativeRotation = transform.InverseTransformDirection(camera.transform.forward);
            relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));
            portalCamera.transform.forward = pairPortal.TransformDirection(relativeRotation);
        }
    }
    
    // Calculates reflection matrix around the given plane
    private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane)
    {
        reflectionMat.m00 = (1F - 2F * plane[0] * plane[0]);
        reflectionMat.m01 = (-2F * plane[0] * plane[1]);
        reflectionMat.m02 = (-2F * plane[0] * plane[2]);
        reflectionMat.m03 = (-2F * plane[3] * plane[0]);

        reflectionMat.m10 = (-2F * plane[1] * plane[0]);
        reflectionMat.m11 = (1F - 2F * plane[1] * plane[1]);
        reflectionMat.m12 = (-2F * plane[1] * plane[2]);
        reflectionMat.m13 = (-2F * plane[3] * plane[1]);

        reflectionMat.m20 = (-2F * plane[2] * plane[0]);
        reflectionMat.m21 = (-2F * plane[2] * plane[1]);
        reflectionMat.m22 = (1F - 2F * plane[2] * plane[2]);
        reflectionMat.m23 = (-2F * plane[3] * plane[2]);

        reflectionMat.m30 = 0F;
        reflectionMat.m31 = 0F;
        reflectionMat.m32 = 0F;
        reflectionMat.m33 = 1F;
    }

    //////////////////////////////////////////////////////
    // Teleportation Code
    //////////////////////////////////////////////////////
    /* private void OnTriggerEnter(Collider other)
    {
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

        if (otherRigidbody)
        {
            if (otherRigidbody.tag == "Player")
            {
                float turnAngle = Quaternion.Angle(pairPortal.transform.rotation, otherRigidbody.transform.rotation);
                otherRigidbody.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().mouseLook.ForceTurnAngle(turnAngle);
            }


            otherRigidbody.transform.position = pairPortal.transform.position + (pairPortal.transform.forward * offset);
            otherRigidbody.transform.rotation = pairPortal.transform.rotation;

            otherRigidbody.velocity = otherRigidbody.velocity.magnitude * pairPortal.transform.forward;
            
        }
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
