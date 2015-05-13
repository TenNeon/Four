using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(ResearchSystem))]
public class ResearchInspector : Editor {

	public override void OnInspectorGUI() {

		DrawDefaultInspector();

		//EditorGUILayout.IntField

		if(GUILayout.Button("Regenerate")) {
			ResearchSystem rs = (ResearchSystem)target;
			rs.Generate();
		}
	}
}