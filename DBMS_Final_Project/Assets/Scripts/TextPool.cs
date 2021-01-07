using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TextPool : MonoBehaviour
{
   [SerializeField] private Text textPrefab;
   [SerializeField] private Canvas result;
   private List<Text> given;
   private Queue<Text> textQueue;
   private Text t;
  

   private void Awake()
   {
      textQueue = new Queue<Text>();
      GrowPool(20);
      given=new List<Text>();
   }

   private void GrowPool(int q)
   {
      for (int i = 0; i < q; i++)
      {
         Text t = Instantiate(textPrefab, Vector3.zero, Quaternion.identity);
         t.gameObject.SetActive(false);
         t.transform.SetParent(this.transform);
         textQueue.Enqueue(t);
      }
   }

   public Text GetFromPool()
   {
         if(textQueue.Count < 1)
            GrowPool(20);
         
         t = textQueue.Dequeue();
         t.transform.SetParent(result.transform);
         given.Add(t);
         return t;
   }

   public void SetFalse()
   {
      foreach (var t in given)
      {
         t.gameObject.SetActive(false);
         textQueue.Enqueue(t);
      }
   }

   

   
}
