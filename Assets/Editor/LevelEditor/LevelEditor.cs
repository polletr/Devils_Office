using UnityEditor;
using UnityEngine;
using System.IO;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using Newtonsoft.Json;

public class LevelEditor : EditorWindow
{

    bool mouseDown;

    float gridSize = 20f;

    float leftPadding = 10;
    float gridPadding = 2;

    int currentOption = 1;
    int currentDirection = 0;

    Color[] options =
    {
            Color.black,
            Color.white,
            new Color(232f / 255f, 232f / 255f, 232f / 255f),
            Color.gray,
            Color.green,
            Color.yellow,
            new Color(141f / 255f, 111f / 255f, 100f / 255f),
            new Color(191f / 255f, 125f / 255f, 26f / 255f),
            new Color(254f / 255f, 153f / 255f, 0f),
            new Color(169f / 255f, 17f / 255f, 18f / 255f),
            new Color(152f / 255f, 245f / 255f, 249f / 255f),
            new Color(6f / 255f, 2f / 255f, 112f / 255f),
            new Color(45f / 255f, 111f / 255f, 196f / 255f),
            new Color(204f / 255f, 108f / 255f, 231f / 255f),
            new Color(173f / 255f, 60f / 255f, 205f / 255f),
            new Color(225f / 255f, 175f / 255f, 175f / 255f),
            new Color(43f / 255f, 97f / 255f, 47f / 255f),
            new Color(235f / 255f, 52f / 255f, 192f / 255f),
            Color.magenta,
            new Color(246f / 255f, 126f / 255f, 22f / 255f),
            Color.magenta,
            new Color(106f / 255f, 182f / 255f, 186f / 255f),
            new Color(187f / 255f, 252f / 255f, 255f / 255f)

};
    char[] orientations =
    {
        'U', 'D', 'L', 'R'
    };
    string[] directions =
    {
        "Up", "Down", "Left", "Right"
    };

    string[] names =
    {
        "Floor",
        "Wall",
        "Wallframe",
        "InvisibleWall",
        "Player",
        "NPC",
        "Coffee Machine",
        "Table",
        "Light Switch",
        "Pitchfork Station",
        "Stamp",
        "Printer",
        "Microwave",
        "PC",
        "PC2",
        "CleaningMaterial",
        "WhiteBoard",
        "Phone",
        "Sofa",
        "Decoration",
        "Shelf",
        "Chair",
        "TV"
    };

    public LevelData myData;

    public Object levelSource;

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

        levelSource = EditorGUILayout.ObjectField("Save File", levelSource, typeof(UnityEngine.TextAsset), false);

        if (levelSource == null)
        {
            return;
        }

        if (GUILayout.Button("Load"))
        {

            if (levelSource != null)
            {
                Debug.Log("Load");
                if (File.Exists("Assets/Level/Levels/SavedTXT/" + levelSource.name + ".txt"))
                {
                    string myDataString = File.ReadAllText("Assets/Level/Levels/SavedTXT/" + levelSource.name + ".txt");
                    myData = JsonConvert.DeserializeObject<LevelData>(myDataString);
                    Debug.Log(myData.grid.Length);
                }
            }
        }

        if (myData != null)
        {
            myData.levelWidth = EditorGUILayout.IntField(myData.levelWidth);
            myData.levelHeight = EditorGUILayout.IntField(myData.levelHeight);

            // myData.grid = new int[myData.levelWidth, myData.levelHeight];
            // myData.directions = new char[myData.levelWidth, myData.levelHeight];


            if (GUILayout.Button("Save"))
            {
                if (levelSource != null)
                {
                    Debug.Log("Save");
                    string myDataString = JsonConvert.SerializeObject(myData);
                    File.WriteAllText("Assets/Level/Levels/SavedTXT/" + levelSource.name + ".txt", myDataString);
                }

            }


            if (GUILayout.Button("Reset"))
            {
                if (EditorUtility.DisplayDialog("Reset", "This will clear your level. Are you sure?!", "Yes", "No"))
                {
                    myData.grid = new int[myData.levelWidth, myData.levelHeight];
                    myData.directions = new char[myData.levelWidth, myData.levelHeight];
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
                        currentDirection = -1;
                    }

                    if (currentOption == i)
                    {
                        EditorGUI.DrawRect(new Rect(r.x - 1, r.y - 1, r.width + 2, r.height + 2), Color.red);
                    }
                }
                EditorGUI.DrawRect(r, options[i]);
            }
            for (int i = 0; i < orientations.Length; i++)
            {
                Rect r = new Rect(leftPadding + i * (gridSize + gridPadding), 180, gridSize, gridSize);

                if (r.Contains(e.mousePosition))
                {
                    GUILayout.Label(directions[i]);

                    if (e.type == EventType.MouseDown && e.button == 0)
                    {
                        currentDirection = i;
                        currentOption = -1;
                    }

                    if (currentDirection == i)
                    {
                        //EditorGUI.DrawRect(, Color.red);
                        Rect clickRect = new Rect(r.x - 1, r.y - 1, r.width + 2, r.height + 2);
                        EditorGUI.TextField(clickRect, "" + orientations[i]);

                        //EditorGUI.TextField(r, "" + orientations[i]);
                    }
                }
                //EditorGUI.DrawRect(r, options[i]);

                EditorGUI.TextField(r, "" + orientations[i]);
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
                        if (currentOption != -1)
                            myData.grid[i, j] = currentOption;

                        if (currentDirection != -1)
                            myData.directions[i, j] = orientations[currentDirection];
                    }

                    int objectType = myData.grid[i, j];
                    char directionType = myData.directions[i, j];
                    GUIStyle style = new GUIStyle();
                    //style.font.material.color = options[objectType];
                    EditorGUI.DrawRect(r, options[objectType]);
                    EditorGUI.TextArea(r, "" + directionType, style);



                }
            }


        }


    }

    void Update()
    {

        this.Repaint();

    }
}