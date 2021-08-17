using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PostEffectBase : MonoBehaviour
{
    void Start()
    {
        CheckResources();
    }

    protected void CheckResources()
    {
        bool isSupport = CheckSupport();
        if (isSupport)
        {
            NotSupport();
        }
    }

    protected bool CheckSupport()
    {
        return true;
    }

    protected void NotSupport()
    {
        enabled = false;
    }

    protected Material CheckShaderAndCreateMaterial(Shader shader, Material material)
    {

        if (shader == null)
        {
            return null;
        }

        if (shader.isSupported && material && material.shader == shader)
        {
            return material;
        }

        if (!shader.isSupported)
        {
            return null;
        }
        else
        {
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;
            if (material)
            {
                return material;
            }
            else
            {
                return null;
            }
        }
    }




}

