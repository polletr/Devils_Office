using UnityEditor;
using UnityEngine;
using System.IO;
//using Unity.Plastic.Newtonsoft.Json;
public class LevelEditor : EditorWindow
{

    bool mouseDown;

    float gridSize = 20f;

    float leftPadding = 10;
    float gridPadding = 2;

    int currentOption = 1;

    Color[] options =
    {
            Color.black,
            Color.white,
            Color.yellow,
            Color.green,
            Color.blue,
            Color.cyan,
        };

    string[] names =
    {
        "Pill",
        "Wall",
        "PacBear",
        "Pill",
        "Ghost",
        "Spawn"
    };

    private LevelData myData;


    // Add menu item named "My Window" to the Window menu
    [MenuItem("Window/Level Editor")]
    public static void ShowWindow()
    {
        //Show existing window instance. If one doesn't exist, make one.
        EditorWindow.GetWindow(typeof(LevelEditor));
    }

    void OnGUI()
    {
        GUILayout.Label("Level Editor", EditorStyles.boldLabel);

        if (myData == null)
        {
            if (File.Exists("Assets/Level/Level.txt"))
            {
                string myDataString = File.ReadAllText("Assets/Level/Level.txt");
                //myData = JsonConvert.DeserializeObject<LevelData>(myDataString);
            }
            else
            {
                myData = new LevelData();
            }
        }

        myData.levelWidth = EditorGUILayout.IntField(myData.levelWidth);
        myData.levelHeight = EditorGUILayout.IntField(myData.levelHeight);

        if (GUILayout.Button("Reset"))
        {
            if (EditorUtility.DisplayDialog("Reset", "This will clear your level. Are you sure?!", "Yes", "No"))
            {
                myData.grid = new int[myData.levelWidth, myData.levelHeight];
            }
        }

        Event e = Event.current;

        if (e.type == EventType.MouseDown && e.button == 0)
        {
            mouseDown = true;
        }
        if (e.type == EventType.MouseUp && e.button == 0)
        {
            mouseDown = false;
        }

        for (int i = 0; i < options.Length; i++)
        {
            Rect r = new Rect(leftPadding + i * (gridSize + gridPadding), 140, gridSize, gridSize);

            if (r.Contains(e.mousePosition))
            {
                GUILayout.Label(names[i]);

                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    currentOption = i;
                }

                if (currentOption == i)
                {
                    EditorGUI.DrawRect(new Rect(r.x - 1, r.y - 1, r.width + 2, r.height + 2), Color.red);
                }
            }
            EditorGUI.DrawRect(r, options[i]);
        }

        for (int i = 0; i < myData.grid.GetLength(0); i++)
        {
            //GetLength(1) will give me the length of the second dimension (=columns)
            for (int j = 0; j < myData.grid.GetLength(1); j++)
            {
                //I can get each individual element of the array, by using both i and j

                Rect r = new Rect(leftPadding + i * (gridSize + gridPadding), 180 + (myData.grid.GetLength(1) - j) * (gridSize + gridPadding), gridSize, gridSize);

                if (mouseDown && r.Contains(e.mousePosition))
                {
                    myData.grid[i, j] = currentOption;
                   // string myDataString = JsonConvert.SerializeObject(myData);
                   // File.WriteAllText("Assets/Level.txt", myDataString);
                }

                int objectType = myData.grid[i, j];
                EditorGUI.DrawRect(r, options[objectType]);
            }
        }

    }

    void Update()
    {

        this.Repaint();

    }
}