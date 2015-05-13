#pragma strict

var lineWidth = 2.0;
var numberOfPoints = 50; // Should be an even number, since we use a discrete line

function Start () {
	var linePoints = new Vector2[numberOfPoints];
	
	for (p in linePoints)
		p = Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));
	
	var lineColors = new Color[numberOfPoints/2];
	
	for (c in lineColors)
		c = Color(Random.value, Random.value, Random.value);
	
	var line = new VectorLine("Line", linePoints, lineColors, null, lineWidth);
	
	line.Draw();
}