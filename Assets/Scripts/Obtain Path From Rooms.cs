//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ObtainPathFromRooms : MonoBehaviour
//{
//    [SerializeField]
//    private Transform[] transforms; 
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Room")
//        {
//            if (collision.gameObject.TryGetComponent<RoomPaths>(out RoomPaths roomPaths))
//            {
//                transforms = roomPaths.transforms;
//            }
//        }
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Room")
//        {
//            Debug.Log("Salimos de la sala!");
//        }
//    }
//}
