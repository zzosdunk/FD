
using UnityEngine;

public class BuildManager : MonoBehaviour {

    //singleton pattern
    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There are more than 1 BuildManager in scene");
            return;
        }
        instance = this; //this buildmanager is going to put into this instance variable
    }


    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;

    private Node selectedNode;
    public NodeUI nodeUI;

    
    public bool CanBuild { get { return turretToBuild != null; } } //if it isnt a null than we can build smth on the node
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } //if we dont have enough money it will return false, if we have enough - true


    public void SelectNode (Node node)
    {
        if (selectedNode == node)
        {
            DeselectedNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectedNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeselectedNode();
    }

    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
