using UnityEngine;

//This class makes use of the spherical fog shader. It does not work on any other shader
[ExecuteInEditMode]
public class Fog : MonoBehaviour
{
    protected MeshRenderer sphericalFogObject;
    //public Camera theCamera;
    public Material sphericalFogMaterial;
    public float scaleFactor = 1;

    void OnEnable()
    {
        sphericalFogObject = gameObject.GetComponent<MeshRenderer>();
        if (sphericalFogObject == null)
            Debug.LogError("Volume Fog Object must have a MeshRenderer Component!");

        //Generate depth texture when camera is in forward lighting path
        //if (theCamera.GetComponent<Camera>().main.depthTextureMode == DepthTextureMode.None)
        //    theCamera.main.depthTextureMode = DepthTextureMode.Depth;

        sphericalFogObject.material = sphericalFogMaterial;

    }

    void Update()
    {
        float radius = (transform.lossyScale.x + transform.lossyScale.y + transform.lossyScale.z) / 6;
        Material mat = Application.isPlaying ? sphericalFogObject.material : sphericalFogObject.sharedMaterial;
        if (mat)
            mat.SetVector("FogParam", new Vector4(transform.position.x, transform.position.y, transform.position.z, radius * scaleFactor));
    }
}
