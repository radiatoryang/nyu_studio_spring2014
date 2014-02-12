using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	// references to our blueprints / PREFABS
	public Transform skyscraperPrefab, shoppingMallPrefab;

	int buildingCount = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if ( buildingCount < 500 )
		{
			float randomNumber = Random.Range (0f, 10f);

			if ( randomNumber < 5.0f)
			{
				// spawn a skyscraper
				Instantiate (skyscraperPrefab, new Vector3( Random.Range (-100f, 100f), 0f, Random.Range (-100f, 100f) ), Quaternion.identity );
			}
			else 
			{
				// spawn a shopping mall
				Instantiate (shoppingMallPrefab, new Vector3( Random.Range (-100f, 100f), 0f, Random.Range (-100f, 100f) ), Quaternion.identity );
			}

			buildingCount = buildingCount + 1;
		} // closes out if(buildingCount)

	} // closes out Update ();
} // close out our class definition
