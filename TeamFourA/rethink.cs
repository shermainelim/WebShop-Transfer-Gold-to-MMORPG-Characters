using RethinkDb.Driver;
using RethinkDb.Driver.Ast;
using RethinkDb.Driver.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TeamFourA
{
    public class rethink
    { //shermaine calling restful api of ReThinkDB to connect to gamedatabase to update coins in real mmo game
        public bool Update(string GameUsername, int Gold)
        {
            try
            {
                RethinkDB R = new RethinkDB();
                Connection conn = R.Connection()
                         .Hostname("localhost")
                         .Port(28015)
                         .Db("mmorpg")
                         //.User("admin", "admin")
                         .Timeout(60)
                         .Connect();

                Console.WriteLine(R.Db("mmorpg").TableList().Run(conn));


                var results = R.Table("users").Filter(g => g["username"].Eq(GameUsername)).Run(conn);

                string id = "";
                foreach (var result in results)
                {
                    id = result["id"];
                }

                var results2 = R.Table("users").GetAll(id).G("stats").G("gold").Run(conn);

                string gold2 = "";
                foreach (var resultd in results2)
                {
                    gold2 = resultd.ToString();
                }


                Console.WriteLine(id);
                int gold3 = Convert.ToInt32(gold2);

                if (id == "")
                {
                    return false;
                }
                R.Table("users").Get(id).Update(R.HashMap("stats", R.HashMap("gold", gold3 + Gold))).Run(conn);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
    }
}
