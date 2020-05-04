using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace VisualDataStructure.Data
{
    public class HashTableService
    {
        public Hashtable Hashtable { get; set; }

        public HashTableService()
        {
            Hashtable = new Hashtable();
        }

        public void Add(string value)
        {
            string key = value;
            while (Hashtable.ContainsKey(GetKey(key)))
            {
                key += "0";
            }

            Hashtable.Add(GetKey(key), value);
        }

        public static string GetKey(string value)
        {
            using HashAlgorithm hashAlgorithm = SHA256.Create();
            return Convert.ToBase64String(hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(value)));
        }

        public void Remove(string value)
        {
            string key;
            do
            {
                key = GetKey(value);
                value += "0";
            } while (!Hashtable.ContainsKey(key));

            Hashtable.Remove(key);
        }
    }
}