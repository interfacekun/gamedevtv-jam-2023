using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputSystem : MonoBehaviour {

    BuildingTypeListSO buildingTypeList;

    private void Start() {
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OptionsUI.Instance.ToggleVisible();
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            CameraHandler.Instance.CenterCameraOnHq();
        }

        

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            BuildingManager.Instance.SetActiveBuildingType(null);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            BuildingManager.Instance.SetActiveBuildingType(buildingTypeList.list[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            BuildingManager.Instance.SetActiveBuildingType(buildingTypeList.list[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {
            BuildingManager.Instance.SetActiveBuildingType(buildingTypeList.list[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5)) {
            BuildingManager.Instance.SetActiveBuildingType(buildingTypeList.list[4]);
        }
    }
}
