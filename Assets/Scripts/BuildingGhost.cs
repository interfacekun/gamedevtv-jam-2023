using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGhost : MonoBehaviour {

    private GameObject spriteGameObject;
    private ResourceNearbyOverlay resourceNearbyOverlay;
    private SpriteRenderer spriteRenderer;
    private Color red = new Color(255, 0, 0, 200);
    private Color white = new Color(255, 255, 255, 200);

    private void Awake() {
        spriteGameObject = transform.Find("sprite").gameObject;
        resourceNearbyOverlay = transform.Find("pfResourceNearbyOverlay").GetComponent<ResourceNearbyOverlay>();
        spriteRenderer = spriteGameObject.GetComponent<SpriteRenderer>();
        Hide();
    }

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e) {
        if (e.activeBuildingType == null) {
            Hide();
            resourceNearbyOverlay.Hide();
        } else {
            Show(e.activeBuildingType.sprite);
            if (e.activeBuildingType.hasResourceGeneratorData) {
                resourceNearbyOverlay.Show(e.activeBuildingType.resourceGeneratorData);
            } else {
                resourceNearbyOverlay.Hide();
            }
        }
    }

    private void Update() {
        transform.position = UtilsClass.GetMouseWorldPosition();

        BuildingTypeSO buildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (buildingType != null) {
            if (!BuildingManager.Instance.CanBuild(buildingType, transform.position)) {
                spriteRenderer.color = red;
            } else {
                spriteRenderer.color = white;
            }
        }
    }

    private void Show(Sprite ghostSprite) {
        spriteGameObject.SetActive(true);
        spriteRenderer.sprite = ghostSprite;
        spriteRenderer.color = white;
    }

    private void Hide() {
        spriteGameObject.SetActive(false);
    }


}
