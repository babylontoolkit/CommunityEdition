#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
    [MenuItem("GameObject/Copy Transform Pose", false, 0)]
    public static void CopyTransformPose()
    {
        TransformData transformDataOfObj01;
       
        Transform obj01 = Selection.activeTransform;
        Transform obj02 = Instantiate(obj01, obj01.position, obj01.rotation);
       
        Transform[] transforms01 = obj01.GetComponentsInChildren<Transform>();
        Transform[] transforms02 = obj02.GetComponentsInChildren<Transform>();
       
        int transLength01 = transforms01.Length;
        int transLength02 = transforms02.Length;
 
        if (transLength01 != transLength02) return; // NOTE: Must be the same character with the same rigged structure
       
        for (int i = 0; i <= transLength01-1; i++)
        {
            transformDataOfObj01 = new TransformData(transforms01[i].transform);
            transformDataOfObj01.ApplyTo(transforms02[i].transform);
        }
    }

    [SerializeField]
    public class TransformData
    {
        public Vector3 LocalPosition = Vector3.zero;
        public Vector3 LocalEulerRotation = Vector3.zero;
        public Vector3 LocalScale = Vector3.one;
    
        // Unity requires a default constructor for serialization
        public TransformData() { }
    
        public TransformData(Transform transform)
        {
            LocalPosition = transform.localPosition;
            LocalEulerRotation = transform.localEulerAngles;
            LocalScale = transform.localScale;
        }
    
        public void ApplyTo(Transform transform)
        {
            transform.localPosition = LocalPosition;
            transform.localEulerAngles = LocalEulerRotation;
            transform.localScale = LocalScale;
        }
    }
}
#endif