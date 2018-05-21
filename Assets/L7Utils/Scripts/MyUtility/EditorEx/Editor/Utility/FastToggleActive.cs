using UnityEngine;
using UnityEditor;


[InitializeOnLoad]
public class FastToggleActive {
	private static bool enable = false;


	[MenuItem("L7/ToggleFastActive")]
	static void ToggleFastActive() {
		enable = !enable;
		EditorPrefs.SetBool("fastToggleActive", enable);
		EditorApplication.RepaintHierarchyWindow();
	}


	static FastToggleActive() {
		EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
		enable = EditorPrefs.GetBool("fastToggleActive", false);
	}

	static void OnHierarchyGUI(int instanceID, Rect selectionRect) {
		if (!enable) {
			return;
		}
		GameObject g = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
		Rect rec = selectionRect;
		rec.x += rec.width - 15f;
		rec.width = 14f;
		if (g) {
			g.SetActive(GUI.Toggle(rec, g.activeSelf, "D"));
		}

	}
}
