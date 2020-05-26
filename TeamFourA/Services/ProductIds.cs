using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TeamFourA.Services
{
    public class ProductIds
    {
        // takes a id string of format "1;2;3", returns List<string>
        public List<string> GetList(string s)
        {
            var newArray = s.Split(';');
            return newArray.ToList();
        }

        // takes a id string of format "1;2;3", returns dictionary<string, int> of key:id and value:count
        public Dictionary<string, int> GetDict(string s)
        {
            var newList = GetList(s);

            var newDict = new Dictionary<string, int>();
            foreach (var p in newList)
            {
                if (!newDict.ContainsKey(p))
                    newDict[p] = 1;
                else
                    newDict[p]++;
            }

            return newDict;
        }

        // add id2 to id1, returns id1 + ";" + id2
        public string AddId(string id1, string id2)
        {
            var productIds = id1;

            if (id1 == null || String.Equals(id1,""))
                return id2;
            else
                return id1 + ";" + id2;
        }
    }
}
