using Project.Gameplay.Movement;
using UnityEditor;
using UnityEngine;

namespace Project.Editor
{
    public static class CameraEditorUtils
    {
        [MenuItem("GameObject/Align Camera To Object")]
        private static void SetCameraTo()
        {
            var selectedGo = Selection.activeGameObject;
            if (!selectedGo)
                return;

            var goTransform = selectedGo.transform;
            var cameraTransform = Object.FindAnyObjectByType<MovementCameraController>().transform;
            cameraTransform.position = goTransform.position;
            cameraTransform.rotation = goTransform.rotation;
        }
        
        [MenuItem("GameObject/Align Camera To Object", true)]
        private static bool SetCameraToValidate()
        {
            var selectedGo = Selection.activeGameObject;
            return selectedGo;
        }
        
        [MenuItem("GameObject/Set Object To Camera")]
        private static void SetObjectToCamera()
        {
            var selectedGo = Selection.activeGameObject;
            if (!selectedGo)
                return;

            var goTransform = selectedGo.transform;
            var cameraTransform = Object.FindAnyObjectByType<MovementCameraController>().transform;
            goTransform.position = cameraTransform.position;
            goTransform.rotation = cameraTransform.rotation;
        }
        
        [MenuItem("GameObject/Set Object To Camera", true)]
        private static bool SetObjectToCameraValidate()
        {
            var selectedGo = Selection.activeGameObject;
            return selectedGo;
        }
    }
}