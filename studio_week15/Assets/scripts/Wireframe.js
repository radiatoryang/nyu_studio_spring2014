
// from http://www.seethroughskin.com/blog/?p=2159
// uses GL.Line calls to draw wireframes directly to GL

var lineColor : Color;
var backgroundColor : Color;
var ZWrite = true;
var AWrite = true;
var blend = true;
var lineWidth = 3;
var size = 0;
 
private var lines : Vector3[];
private var linesArray : Array;
private var lineMaterial : Material;
private var meshRenderer : MeshRenderer; 

function Start () 
{
InvokeRepeating( "UpdateWireframe", 0f, 0.1f );

}
 
function UpdateWireframe () {
    meshRenderer = GetComponent(MeshRenderer);
	lineMaterial = new Material( "Shader \"Lines/Colored Blended\" {" +
		"SubShader { Pass {" +
		"   BindChannels { Bind \"Color\",color }" +
		"   Blend SrcAlpha OneMinusSrcAlpha" +
		"   ZWrite on Cull Off Fog { Mode Off }" +
		"} } }");
 
	lineMaterial = new Material("Shader \"Lines/Colored Blended\" {"+
		"SubShader { Pass {"+
		"	Blend SrcAlpha OneMinusSrcAlpha"+
		"	ZWrite Off Cull Front Fog { Mode Off }"+
		"} } }");
 
	lineMaterial.hideFlags = HideFlags.HideAndDontSave;
	lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
    linesArray = new Array();
 
    var filter : MeshFilter = GetComponent(MeshFilter);
    var mesh = filter.mesh;
    var vertices = mesh.vertices;
    var triangles = mesh.triangles;
 
    for (i = 0; i < triangles.length / 3; i++)
    {
        linesArray.Add(TransformVertex(vertices[triangles[i * 3]]));
        linesArray.Add(TransformVertex(vertices[triangles[i * 3 + 1]]));
        linesArray.Add(TransformVertex(vertices[triangles[i * 3 + 2]]));
    }
 
    lines = linesArray.ToBuiltin(Vector3);
    size = lines.Length;
}
 
function TransformVertex(v : Vector3) : Vector3 {
	var ret  = (transform.rotation * v + transform.position);
	ret.x *= transform.lossyScale.x;
	ret.y *= transform.lossyScale.y;
	ret.z *= transform.lossyScale.z;
 
	return ret;
}
 
// to simulate thickness, draw line as a quad scaled along the camera's vertical axis.
function DrawQuad(p1 : Vector3, p2: Vector3 ){
	var thisWidth = 1.0/Screen.width * lineWidth * .5;
	var edge1 = Camera.main.transform.position - (p2+p1)/2.0;	//vector from line center to camera
	var edge2 = p2-p1;	//vector from point to point
        var perpendicular = Vector3.Cross(edge1,edge2).normalized * thisWidth;
 
	GL.Vertex(p1 - perpendicular);
	GL.Vertex(p1 + perpendicular);
	GL.Vertex(p2 + perpendicular);
	GL.Vertex(p2 - perpendicular);
}
 
function OnRenderObject () {
	if (!lines || lines.Length < 2) {
		Debug.Log("No lines");
		return;
	}
 
	lineMaterial.SetPass(0);
	GL.Color(lineColor);
 
	if (lineWidth == 1) {
		GL.Begin(GL.LINES);
		for (i = 0; i < lines.length / 3; i++)
	    {
	        GL.Vertex(lines[i * 3]);
	        GL.Vertex(lines[i * 3 + 1]);
 
	        GL.Vertex(lines[i * 3 + 1]);
	        GL.Vertex(lines[i * 3 + 2]);
 
	        GL.Vertex(lines[i * 3 + 2]);
	        GL.Vertex(lines[i * 3]);
	    }
	} else {
		GL.Begin(GL.QUADS);
		for (i = 0; i < lines.length/3; i++) {
			DrawQuad(lines[i * 3],lines[i * 3+1]);
			DrawQuad(lines[i * 3+1],lines[i * 3+2]);
			DrawQuad(lines[i * 3+2],lines[i * 3]);
		}
	}
	GL.End();
}