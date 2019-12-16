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

            foreach (var user in users)
            {
                var process = ExtractAllPath(user);
                List<UserNode> friendsAtDistance = FriendOfFriendsAtGivenDistance(user, 4);
                foreach (var f in friendsAtDistance)
                {
                    Console.WriteLine(f);

                }
            }
            Console.WriteLine("minimum distance : " + MinDistance(users[0], users[2]));
            FriendsOfFriendsDistance(users[0]);


            //Console.WriteLine(res);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static void FriendsOfFriendsDistance(UserNode user)
        {

            //Console.WriteLine(user.FirstName + " " + user.LastName + " Friend of friends: " + ExtractChilds(user).Count);

        }

        public static List<UserNode> FriendOfFriendsAtGivenDistance(UserNode user, int distance)
        {
            List<UserNode> friends = new List<UserNode>();
            Queue que = new Queue();
            que.Enqueue(user);
            List<UserNode> visited = new List<UserNode>();
            while (que.Count > 0)
            {
                UserNode actualVisit = (UserNode)que.Dequeue();
                if (visited.Contains(actualVisit)) { continue; }
                foreach (UserNode neighbor in actualVisit.Friends)
                {
                    que.Enqueue(neighbor);
                }
                visited.Add(actualVisit);
                if (que.Count <= distance)
                {
                    if (!friends.Contains(actualVisit))
                    {
                        friends.Add(actualVisit);
                    }
                }
            }
            return friends;
        }

        public static int MinDistance(UserNode user, UserNode user2)
        {
            Queue que = new Queue();
            que.Enqueue(user);
            List<UserNode> visited = new List<UserNode>();
            int minDistance = 111110;
            while (que.Count > 0)
            {
                UserNode actualVisit = (UserNode)que.Dequeue();
                if (visited.Contains(actualVisit)) { continue; }
                //Console.WriteLine($"Runtime -> Actual : {actualVisit.FirstName} {actualVisit.LastName} (friends: {actualVisit.Friends.Count} )");
                foreach (UserNode neighbor in actualVisit.Friends)
                {
                    que.Enqueue(neighbor);
                    //Console.WriteLine($"Runtime -> test count: {neighbor.FirstName} {neighbor.LastName} (friends: {neighbor.Friends.Count} )");
                    if (neighbor == user2)
                    {
                        if (que.Count < minDistance)
                        {
                            minDistance = que.Count;

                        }
                        Console.WriteLine($"MEGVAGY {que.Count}");
                    }

                }
                visited.Add(actualVisit);
            }
            return minDistance;
        }

        public static void ShortestDistance()
        {

        }
        public static LinkedList<UserNode> ExtractChilds(UserNode user, UserNode parent)
        {
            //Console.WriteLine($"Child : {user.FirstName} {user.LastName} {user.Friends.Count}");
            Queue nodeQue = new Queue();
            LinkedList<UserNode> friendOrder = new LinkedList<UserNode>();
            List<UserNode> visited = new List<UserNode>();
            nodeQue.Enqueue(user);

            while (nodeQue.Count > 0)
            {
                UserNode actual = (UserNode)nodeQue.Dequeue();
                if (!friendOrder.Contains(parent))
                {
                    friendOrder.AddFirst(parent);
                }

                foreach (UserNode friend in actual.Friends)
                {
                    if (friendOrder.Contains(friend))
                    {
                        continue;
                    }
                    if (!visited.Contains(friend))
                    {
                        friendOrder.AddLast(friend);
                        nodeQue.Enqueue(friend);
                        visited.Add(friend);
                        break;
                    }
                    if (visited.Contains(friend))
                    {
                        break;
                    }
                }

            }

            return friendOrder;
        }
        public static Queue ExtractAllPath(UserNode user)
        {
            Queue result = new Queue();
            //Console.WriteLine($"Parent : {user.FirstName} {user.LastName} ({user.Friends.Count})");
            foreach (UserNode node in user.Friends)
                result.Enqueue(ExtractChilds(node, user));

            return result;
        }
    }
}
