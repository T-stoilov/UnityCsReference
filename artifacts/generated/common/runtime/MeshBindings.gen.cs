// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using scm=System.ComponentModel;
using uei=UnityEngine.Internal;
using RequiredByNativeCodeAttribute=UnityEngine.Scripting.RequiredByNativeCodeAttribute;
using UsedByNativeCodeAttribute=UnityEngine.Scripting.UsedByNativeCodeAttribute;

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;

namespace UnityEngine
{


internal sealed partial class NoAllocHelpers
{
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public static  void ResizeList (object list, int size) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public static  System.Array ExtractArrayFromList (object list) ;

    
    
    public static int SafeLength(System.Array values)
        {
            return values != null ? values.Length : 0;
        }
    
    
    public static int SafeLength<T>(List<T> values)
        {
            return values != null ? values.Count : 0;
        }
    
    
}

[System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
internal partial struct CombineInstanceHelper
{
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern internal static  Mesh GetMesh (int instanceID) ;

}

[System.Runtime.InteropServices.StructLayout (System.Runtime.InteropServices.LayoutKind.Sequential)]
internal partial struct StaticBatchingHelper
{
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern internal static  Mesh InternalCombineVertices (MeshSubsetCombineUtility.MeshInstance[] meshes, string meshName) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern internal static  void InternalCombineIndices (MeshSubsetCombineUtility.SubMeshInstance[] submeshes, [Writable] Mesh combinedMesh) ;

}

public sealed partial class Mesh : Object
{
    public Mesh()
        {
            Internal_Create(this);
        }
    
    
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private static  void Internal_Create ([Writable] Mesh mono) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void SetArrayForChannelImpl (InternalShaderChannel channel, InternalVertexChannelType format, int dim, System.Array values, int arraySize) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private System.Array GetAllocArrayFromChannelImpl (InternalShaderChannel channel, InternalVertexChannelType format, int dim) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void GetArrayFromChannelImpl (InternalShaderChannel channel, InternalVertexChannelType format, int dim, System.Array values) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern internal bool HasChannel (InternalShaderChannel channel) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private int[] GetTrianglesImpl (int submesh) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void GetTrianglesNonAllocImpl (object values, int submesh) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private int[] GetIndicesImpl (int submesh) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void GetIndicesNonAllocImpl (object values, int submesh) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void SetTrianglesImpl (int submesh, System.Array triangles, int arraySize, [uei.DefaultValue("true")]  bool calculateBounds ) ;

    [uei.ExcludeFromDocs]
    private void SetTrianglesImpl (int submesh, System.Array triangles, int arraySize) {
        bool calculateBounds = true;
        SetTrianglesImpl ( submesh, triangles, arraySize, calculateBounds );
    }

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void SetIndicesImpl (int submesh, MeshTopology topology, System.Array indices, int arraySize, [uei.DefaultValue("true")]  bool calculateBounds ) ;

    [uei.ExcludeFromDocs]
    private void SetIndicesImpl (int submesh, MeshTopology topology, System.Array indices, int arraySize) {
        bool calculateBounds = true;
        SetIndicesImpl ( submesh, topology, indices, arraySize, calculateBounds );
    }

    [uei.ExcludeFromDocs]
public void SetTriangles (int[] triangles, int submesh) {
    bool calculateBounds = true;
    SetTriangles ( triangles, submesh, calculateBounds );
}

public void SetTriangles(int[] triangles, int submesh, [uei.DefaultValue("true")]  bool calculateBounds )
        {
            if (CheckCanAccessSubmeshTriangles(submesh))
                SetTrianglesImpl(submesh, triangles, NoAllocHelpers.SafeLength(triangles), calculateBounds);
        }

    
    
    [uei.ExcludeFromDocs]
public void SetTriangles (List<int> triangles, int submesh) {
    bool calculateBounds = true;
    SetTriangles ( triangles, submesh, calculateBounds );
}

public void SetTriangles(List<int> triangles, int submesh, [uei.DefaultValue("true")]  bool calculateBounds )
        {
            if (CheckCanAccessSubmeshTriangles(submesh))
                SetTrianglesImpl(submesh, NoAllocHelpers.ExtractArrayFromList(triangles), NoAllocHelpers.SafeLength(triangles), calculateBounds);
        }

    
    
    [uei.ExcludeFromDocs]
public void SetIndices (int[] indices, MeshTopology topology, int submesh) {
    bool calculateBounds = true;
    SetIndices ( indices, topology, submesh, calculateBounds );
}

public void SetIndices(int[] indices, MeshTopology topology, int submesh, [uei.DefaultValue("true")]  bool calculateBounds )
        {
            if (CheckCanAccessSubmeshIndices(submesh))
                SetIndicesImpl(submesh, topology, indices, NoAllocHelpers.SafeLength(indices), calculateBounds);
        }

    
    
    
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public void GetBlendShapeFrameVertices (int shapeIndex, int frameIndex, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public void AddBlendShapeFrame (string shapeName, float frameWeight, Vector3[] deltaVertices, Vector3[] deltaNormals, Vector3[] deltaTangents) ;

    public Bounds bounds
    {
        get { Bounds tmp; INTERNAL_get_bounds(out tmp); return tmp;  }
        set { INTERNAL_set_bounds(ref value); }
    }

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void INTERNAL_get_bounds (out Bounds value) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void INTERNAL_set_bounds (ref Bounds value) ;

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Obsolete("This method is no longer supported (UnityUpgradable)", true)]
    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public void Optimize () ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public MeshTopology GetTopology (int submesh) ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern public void CombineMeshes (CombineInstance[] combine, [uei.DefaultValue("true")]  bool mergeSubMeshes , [uei.DefaultValue("true")]  bool useMatrices , [uei.DefaultValue("false")]  bool hasLightmapData ) ;

    [uei.ExcludeFromDocs]
    public void CombineMeshes (CombineInstance[] combine, bool mergeSubMeshes , bool useMatrices ) {
        bool hasLightmapData = false;
        CombineMeshes ( combine, mergeSubMeshes, useMatrices, hasLightmapData );
    }

    [uei.ExcludeFromDocs]
    public void CombineMeshes (CombineInstance[] combine, bool mergeSubMeshes ) {
        bool hasLightmapData = false;
        bool useMatrices = true;
        CombineMeshes ( combine, mergeSubMeshes, useMatrices, hasLightmapData );
    }

    [uei.ExcludeFromDocs]
    public void CombineMeshes (CombineInstance[] combine) {
        bool hasLightmapData = false;
        bool useMatrices = true;
        bool mergeSubMeshes = true;
        CombineMeshes ( combine, mergeSubMeshes, useMatrices, hasLightmapData );
    }

    public extern  BoneWeight[] boneWeights
    {
        [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
        [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
        get;
        [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
        [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
        set;
    }

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void GetBoneWeightsNonAllocImpl (object values) ;

    public extern  Matrix4x4[] bindposes
    {
        [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
        [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
        get;
        [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
        [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
        set;
    }

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private int GetBindposeCount () ;

    [UnityEngine.Scripting.GeneratedByOldBindingsGeneratorAttribute] // Temporarily necessary for bindings migration
    [System.Runtime.CompilerServices.MethodImplAttribute((System.Runtime.CompilerServices.MethodImplOptions)0x1000)]
    extern private void GetBindposesNonAllocImpl (object values) ;

}


}