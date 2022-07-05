using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LGAMES.WordFight
{
    [InitializeOnLoad]
    public class HierarchyObject : MonoBehaviour
    {

        private static readonly List<string> objectNameList = new()
        { 
            "CAMERAS",
            "CHARACTERS",
            "CONTROLLERS",
            "ENEMIES",
            "ENVIRONMENTS",
            "HANDLERS",
            "LEVELS",
            "LIGHTNINGS",
            "MANAGERS",
            "OBSTACLES",
            "PLAYERS",
            "POST PROCESSING",
            "RUN",
            "RUN ON CREATE",
            "UI",
            "USER INTERFACE"
        };

        private static Vector2 offset = new(20, 1);

        static HierarchyObject()
        {
            EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
        }

        private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceID);

            if (obj != null)
            {
                Color backgroundColor = Color.white;
                Color textColor = Color.white;
                Texture2D texture = null;

                foreach (string objName in objectNameList)
                {
                    if (objName.Equals(obj.name))
                    {
                        backgroundColor = new Color32(48, 86, 86, 255);
                        textColor = Color.yellow;
                    }
                }

                if (backgroundColor != Color.white)
                {
                    Rect offsetRect = new(selectionRect.position + offset, selectionRect.size);
                    Rect bgRect = new(selectionRect.x, selectionRect.y, selectionRect.width + 50, selectionRect.height);

                    EditorGUI.DrawRect(bgRect, backgroundColor);
                    EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = textColor },
                        fontStyle = FontStyle.Bold
                    });

                    if (texture != null)
                        EditorGUI.DrawPreviewTexture(new Rect(selectionRect.position, new Vector2(selectionRect.height, selectionRect.height)), texture);
                }
            }
        }

    }
}
