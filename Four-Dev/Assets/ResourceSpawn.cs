using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceSpawn : MonoBehaviour {
	public Vector2 SpawnZonePoint = Vector2.zero;
	public float SpawnZoneRadius = 1;
	public float SpawnsPerSecond = 1;
	public Transform outputPrefab;
	public int SpawnAmount = 1;
	public string Name = "Spawner";
	int amountSpawned = 0;
	float AmountToSpawn = 0;
	float LastUpdate = 0;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Tick",0,1f);
	}
	
	// Update is called once per frame
	void Update () {
		Tick ();


	}

	void Tick ()
	{
		AmountToSpawn += Time.deltaTime * SpawnsPerSecond;
		while(AmountToSpawn >= 1)
		{
			for (int i = 0; i < SpawnAmount; i++) {
				var ouc = OnUnitCircle()*Random.Range(0, SpawnZoneRadius );
				var spawnLocation = transform.position + new Vector3(SpawnZonePoint.x, SpawnZonePoint.y,-.1f) + new Vector3(ouc.x,ouc.y,0);
				var collider = outputPrefab.GetComponent<BoxCollider2D>() as BoxCollider2D;
				var outputSize = collider.size;
				Vector2 TopLeft = new Vector2(spawnLocation.x-outputSize.x/2, spawnLocation.y-outputSize.y/2);
				Vector2 BottomRight= new Vector2(spawnLocation.x+outputSize.x/2, spawnLocation.y+outputSize.y/2);
				if (!Physics2D.OverlapArea(TopLeft, BottomRight))
				{
					var outputTransform = Instantiate(outputPrefab, spawnLocation, transform.rotation) as Transform; 	
					amountSpawned++;
					outputTransform.name = "Item " + amountSpawned;
					outputTransform.SetParent(this.transform);
				}
			}
			AmountToSpawn--;
		}
	}

	Vector2 OnUnitCircle()
	{
		//generate a point in the unit circle
		Vector2 initialPoint = Random.insideUnitCircle;
		if(initialPoint == Vector2.zero)
		{
			// on the freak chance that the random vector is zero,
			// decide that it is actually one
			return Vector2.one;
		}
		//extend point to edge
		return initialPoint.normalized;
	}
}
