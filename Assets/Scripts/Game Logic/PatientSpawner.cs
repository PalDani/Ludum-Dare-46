using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientSpawner : MonoBehaviour
{
    public AmbulanceCar ambulanceCar;
    public Transform npcSpawnPosition;
    public GameObject[] npcModels;

    [Header("Spawner settings")]
    public float minPatientSpawnCount = 1;
    public float maxPatientSpawnCount = 2;
    public float minDelayBetweenSpawns = 10;
    public float maxDelayBetweenSpawns = 30;

    [Header("Runtime data")]
    [SerializeField] private int npcSpawnCount = 0;

    void Start()
    {
        StartAmbulanceCar();
    }

    void Update()
    {
        
    }

    public void StartAmbulanceCar()
    {
        ambulanceCar.Arrive();
        StartCoroutine(SpawnNpc());
    }

    private IEnumerator SpawnNpc()
    {
        yield return new WaitForSeconds(3.5f);
        //Spawn NPC(s)

        GameObject npc = Instantiate(npcModels[0], npcSpawnPosition.position, Quaternion.identity);
        npcSpawnCount++;
        npc.GetComponentInChildren<Patient>().ConstructPatient();

        npc.GetComponentInChildren<AmbulantNPC>().npcObj.animator.SetBool("Move", true);

        yield return new WaitForSeconds(1);
        npc.GetComponent<NPC>().ClickDetector.GetComponent<BoxCollider>().size = new Vector3(2, 1.33f, 2.31f);
        npc.GetComponent<NPC>().ClickDetector.GetComponent<BoxCollider>().center = new Vector3(-0.007019f, -1.03f, 1.64f);

        //yield return new WaitForSeconds(0.35f);
        //ambulanceCar.Leave();

        yield return new WaitForSeconds(2 + Random.Range(minDelayBetweenSpawns, maxDelayBetweenSpawns));
        StartAmbulanceCar();
    }
}
