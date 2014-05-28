using UnityEngine;
using System.Collections;

// interactive mesh deformation = next gen 3D art tool???
public class NotMayaSculptBlank : MonoBehaviour {
	
	MeshFilter mf;
	const float brushSize = 0.2f;
	public bool visualizeNormals = false;
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit rayHit = new RaycastHit();
		
		if ( Physics.Raycast(ray, out rayHit, 1000f) ) {
			// make sure you have Draw Gizmos enabled in Game tab to see where you're clicking
			Debug.DrawRay ( rayHit.point, rayHit.normal * 0.1f, Color.yellow );
			
			if ( Input.GetMouseButton(0) ) {
				// convert click position from world space to local (mesh) space
				Vector3 clickPoint = rayHit.transform.InverseTransformPoint ( rayHit.point );
				Vector3 clickNormal = rayHit.transform.InverseTransformDirection ( rayHit.normal );
			
				// grab mesh data so we can do stuff with it
				mf = rayHit.transform.GetComponent<MeshFilter>();
				// REALLY IMPORTANT: make a local copy of the data, don't grab it directly
				Vector3[] vertices = mf.mesh.vertices;
				
				// deform the mesh data; extrude based on click position
				for( int i=0; i<vertices.Length; i++ ) {
					float distanceFromClickPoint = Vector3.Distance(clickPoint, vertices[i]);
					if( distanceFromClickPoint < brushSize ) { // ... but only if the vertex is close enough to where we clicked
						vertices[i] += clickNormal * Time.deltaTime * 0.1f;
					}
				}
				
				// put our edited mesh data back into the mesh
				mf.mesh.vertices = vertices;
				
				// tell mesh to recalculate stuff based on new changes
				mf.mesh.RecalculateNormals ();
				mf.mesh.RecalculateBounds ();
				
				// put mesh back into the MeshCollider
				rayHit.collider.GetComponent<MeshCollider>().sharedMesh = null;
				rayHit.collider.GetComponent<MeshCollider>().sharedMesh = mf.mesh;
				
			} // closes MouseClick
			
		} // closes Raycast
		
		// visualize mesh vertex normals, if enabled
		if ( mf != null && visualizeNormals ) {
			Vector3[] vertices = mf.mesh.vertices;
			Vector3[] normals = mf.mesh.normals;
			for ( int i=0; i<vertices.Length; i++) {
				Debug.DrawRay ( mf.transform.TransformPoint (vertices[i]), mf.transform.TransformDirection (normals[i]) * 0.1f, new Color(1f, 1f, 1f, 0.4f ) );
			}
		}
		
		// let us export the mesh in the MeshFilter component out into a string, then put that string into a file on our desktop
		if ( mf != null && Input.GetKeyDown (KeyCode.S) ) {
			ObjExporter.MeshToFile ( mf, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/notMaya.obj" );
			Debug.Log ("saved notMaya.obj to your desktop!");
		}
		
	} // closes Update()
} // closes class
