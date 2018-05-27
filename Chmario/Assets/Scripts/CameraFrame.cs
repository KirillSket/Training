using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraFrame : MonoBehaviour
{
    [SerializeField]
    private float camSpid = 5f;
    [SerializeField]
    private Rect box;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = Matrix4x4.TRS(Vector2.zero, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(box.center, box.size);
    }

    private Transform player;
    private float _x, _y;
    private void Awake()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (transform.position != player.position)
        {
            Rect b = box;
            _x = ChekerCameraPosition(b.xMin, b.xMax, player.position.x);
            _y = ChekerCameraPosition(b.yMin, b.yMax, player.position.y);
            transform.position = Vector3.Lerp(transform.position, new Vector3(_x, _y, -9f), Time.deltaTime * camSpid);
        }
    }

    private float ChekerCameraPosition(float minNum, float maxMun, float playrPos)
    {
        float curNum;
        if (minNum > playrPos) curNum = minNum;
        else if (playrPos > maxMun) curNum = maxMun;
        else curNum = playrPos;
        return curNum;
    }

}

