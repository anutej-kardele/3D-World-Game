using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] 
    private int width, height;
    [SerializeField] 
    private Tile tilePrefabColor1;
    [SerializeField] 
    private Tile tilePrefabColor2;
    private Tile tile;
    [SerializeField]
    private GameObject[] spawnObjs;
    private GameObject spawnObj;
    [SerializeField]
    private Button[] obj;

    public GameObject list;
    public GameObject listControll;
    //private Tile tilescript;
    //[SerializeField]
    //private Material highlightMaterial;
    [SerializeField]
    private string selectable = "Selectable";
    private int a = 0;
    private Vector3 mousePos;
    private void Start()
    {
        gridCreater();
        tile = tilePrefabColor1;
    }

    private void Update()
    {
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        mousePos = Input.mousePosition;


        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            string name = selection.name;
            if (selection.CompareTag(selectable))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null && Input.GetKeyDown(KeyCode.Mouse0)) 
                {
                    var spawn = Instantiate(spawnObj, new Vector3(name[0]-48, 0.0f, name[1]-48), Quaternion.identity);
                    //spawnObject();
                    Debug.Log(name[0]);
                    Debug.Log(name[1]);
                }
            }
        }
    }
    void gridCreater()
    {
        for(int x = 0;x < width; x+=1)
        {
            for(int z = 0;z < height; z+=1)
            {
                if (tile == tilePrefabColor1)
                    tile = tilePrefabColor2;
                else      
                    tile = tilePrefabColor1;
                var spawnTile = Instantiate(tile, new Vector3(x, 0, z), Quaternion.identity);
                spawnTile.name = $"{x}{z}";
                a++;
            }
        }
    }

    public void object1call()
    {
        spawnObj = spawnObjs[0];
        listControll.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
    }
    public void object2call()
    {
        spawnObj = spawnObjs[1];
        listControll.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
    }
    public void object3call()
    {
        spawnObj = spawnObjs[2];
        listControll.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
    }
    public void object4call()
    {
        spawnObj = spawnObjs[3];
        listControll.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
    }
    public void object5call()
    {
        spawnObj = spawnObjs[4];
        listControll.gameObject.SetActive(true);
        list.gameObject.SetActive(false);
    }

    public void listcontroller()
    {
        list.gameObject.SetActive(true);
        listControll.gameObject.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
