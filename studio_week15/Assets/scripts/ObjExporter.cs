// taken from: http://wiki.unity3d.com/index.php?title=ObjExporter
// for more on the OBJ file format: http://en.wikipedia.org/wiki/Wavefront_.obj_file

using UnityEngine;
using System.Collections;
using System.IO; // needed for file writing operations
using System.Text; // needed for StringBuilder operations

// notice that this class does NOT inherit from MonoBehaviour...
// ... and all the functions are "public static"...
// ... so you would NOT drag this script onto an object, you can't!
public class ObjExporter {

	// exports the string (see below) into a file
	public static void MeshToFile(MeshFilter mf, string filename) {
		using (StreamWriter sw = new StreamWriter(filename)) 
		{
			sw.Write(MeshToString(mf));
		}
	}

	// basically just converts the 3D mesh data into a really long string... *all files* are basically just really long strings
	public static string MeshToString(MeshFilter mf) {
		Mesh m = mf.mesh;
		Material[] mats = mf.renderer.sharedMaterials;
		
		// PRO-TIP: remember that "concatenate" is a fancy word for adding or gluing strings together
		// "StringBuilder" is used when you're concatenating many strings many times, like hundreds / thousands / millions of times...
		// ... if you don't use StringBuilder, each time you concatenate a string = A NEW STRING IN MEMORY... this adds up really quickly...
		// ... so the StringBuilder prevents that, which means much less memory use and much faster string operations.
		StringBuilder sb = new StringBuilder();
		
		sb.Append("g ").Append(mf.name).Append("\n"); // so instead of saying "string1 + string2", StringBuilder uses "Append(string1)"
		foreach(Vector3 v in m.vertices) {
			sb.Append(string.Format("v {0} {1} {2}\n",v.x,v.y,v.z));  // string.Format replaces placeholders with values... {0} = v.x, etc.
		}
		sb.Append("\n");
		foreach(Vector3 v in m.normals) {
			sb.Append(string.Format("vn {0} {1} {2}\n",v.x,v.y,v.z));
		}
		sb.Append("\n");
		foreach(Vector3 v in m.uv) {
			sb.Append(string.Format("vt {0} {1}\n",v.x,v.y));
		}
		for (int material=0; material < m.subMeshCount; material ++) {
			sb.Append("\n");
			sb.Append("usemtl ").Append(mats[material].name).Append("\n");
			sb.Append("usemap ").Append(mats[material].name).Append("\n");
			
			int[] triangles = m.GetTriangles(material);
			for (int i=0;i<triangles.Length;i+=3) {
				sb.Append(string.Format("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}\n", 
				                        triangles[i]+1, triangles[i+1]+1, triangles[i+2]+1)); // notice they have to +1 on each index? .OBJ arrays start at 1
			}
		}
		return sb.ToString(); // at the end, tell StringBuilder to bake a real string
	}
	

}