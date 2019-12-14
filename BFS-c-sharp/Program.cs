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
            Console.WriteLine($"users: {users.Count}");
            int res = MinDistance(users[0], users[2]);
            foreach (var user in users)
            {
                //Console.WriteLine(user);
            }
            

            Console.WriteLine(res);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static void FriendsOfFriendsDistance(UserNode user)
        {

        }

        public static int MinDistance(UserNode user, UserNode user2)
        {
            int testCount = 0;
            Queue que = new Queue();
            que.Enqueue(user);
            List<UserNode> visited = new List<UserNode>();
            HashSet<int> userMap = new HashSet<int>();
            while(que.Count > 0)
            {
                UserNode actualVisit = (UserNode)que.Dequeue();
                if (visited.Contains(actualVisit)) { continue; }
                Console.WriteLine($"Runtime -> Actual : {actualVisit.FirstName} {actualVisit.LastName} (friends: {actualVisit.Friends.Count} )");
                foreach(UserNode neighbor in actualVisit.Friends)
                {
                    testCount++;
                    que.Enqueue(neighbor);
                    Console.WriteLine($"Runtime -> test count: {testCount}, {neighbor.FirstName} {neighbor.LastName} (friends: {neighbor.Friends.Count} )");
                    if(neighbor == user2)
                    {
                        Console.WriteLine("MEGVAGY GECI");
                    }

                }
                visited.Add(actualVisit);
                Console.WriteLine();
            }
            Console.WriteLine($"test count: {testCount}");
            return visited.Count;
        }

        public static void ShortestDistance()
        {

        }
    }
}
