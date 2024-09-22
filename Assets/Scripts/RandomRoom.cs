using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRoom : MonoBehaviour
{
    [SerializeField] private Mesh floor;
    [SerializeField] private Color color;
    [SerializeField] private Vector3 scale;
    [SerializeField] private float miniDistance, minimumDistance, maximumDistance;

    public Vector3 roomPosition;

    private List<Vector3> oldRoomPositions = new List<Vector3>();
    [SerializeField] private int[] numberOfRooms;


    // Start is called before the first frame update

    public void Start()
    {
        for (int i = 0; i < numberOfRooms.Length; i++)
        {
            Vector3 oldRoomPos = roomPosition;
            roomPosition = Vector3.zero;
            roomPosition = new Vector3(Random.Range(minimumDistance, maximumDistance), 0f, Random.Range(minimumDistance, maximumDistance)) +oldRoomPos;

            GameObject room = CreatingRoom(roomPosition);
            oldRoomPositions.Add(room.transform.position);
        }


    }

    public GameObject CreatingRoom(Vector3 position)
    {
        GameObject floorOb = new GameObject("Floor");

        MeshFilter mfilter = floorOb.AddComponent<MeshFilter>();
        MeshRenderer mrender = floorOb.AddComponent<MeshRenderer>();

        mfilter.mesh = floor;

        floorOb.transform.position = position;
        floorOb.transform.localScale = new Vector3(Random.Range(2, scale.x), scale.y, Random.Range(2, scale.z));
        return floorOb;
    }


}
