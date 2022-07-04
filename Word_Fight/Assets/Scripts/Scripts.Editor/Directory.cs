using UnityEngine;
using UnityEditor;
using static System.IO.Directory;
using static System.IO.Path;
using static UnityEngine.Application;
using static UnityEditor.AssetDatabase;

namespace LGAMES.WordFight
{
    public static class Directory
    {


        [MenuItem("LGames/Create Folder/Animation")]
        public static void CreateAnimationDir() => CreateNewDirectory("Animations", "Animations.NewFolder");


        [MenuItem("LGames/Create Folder/Art")]
        public static void CreateArtDir() => CreateNewDirectory("Arts", "Arts.NewFolder");


        [MenuItem("LGames/Create Folder/Prefab")]
        public static void CreatePrefabDir() => CreateNewDirectory("Prefabs", "Prefabs.NewFolder");


        [MenuItem("LGames/Create Folder/Scene")]
        public static void CreateSceneDir() => CreateNewDirectory("Scenes", "Scene.NewFolder");


        [MenuItem("LGames/Create Folder/Script")]
        public static void CreateScriptDir() => CreateNewDirectory("Scripts", "Scripts.NewFolder");


        private static void CreateNewDirectory(string path, string folderName)
        {
            CreateDirectory(Combine(dataPath + "/" + path, folderName));
            Refresh();
        }


    }
}
