using UnityEngine;
using System.Collections;

public class MeshFaderGlobal : MonoBehaviour
{
    public MeshFader[] Meshes;

    public void SetInvisible()
    {
        for (int i = 0; i < Meshes.Length; i++)
        {
            Meshes[i].fadetoInvisible();
        }
    }

    public void SetVisible()
    {
        for (int i = 0; i < Meshes.Length; i++)
        {
            Meshes[i].fadetoVisible();
        }
    }
}
