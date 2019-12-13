using BFS_c_sharp.Model;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();
            int res = MinDistance(users[0], users[2]);
            foreach (var user in users)
            {
                //Console.WriteLine(user);
            }

            Console.WriteLine(res);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public void FriendsOfFriendsDistance(UserNode user)
        {

        }

        public static int MinDistance(UserNode user, UserNode user2)
        {
            Queue que = new Queue();
            que.Enqueue(user);
            while(que.Count > 0)
            {
                UserNode actualVisit = (UserNode)que.Dequeue();
                foreach(UserNode neighbor in actualVisit.Friends)
                {
                    if (!que.Contains(neighbor))
                    {
                        que.Enqueue(neighbor);
                    }
                }
            }
            return 0;
        }
    }
}
