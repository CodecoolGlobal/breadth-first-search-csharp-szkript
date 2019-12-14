﻿using BFS_c_sharp.Model;
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
            //int res = MinDistance(users[0], users[2]);
            FriendsOfFriendsDistance(users[0]);
            foreach (var user in users)
            {
                //Console.WriteLine(user);
            }
            //Console.WriteLine(res);
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public static void FriendsOfFriendsDistance(UserNode user)
        {
            Console.WriteLine($"user info -> {user.FirstName} {user.LastName} (friends: {user.Friends.Count})");
            Queue queue = new Queue();
            List<int> depthDistance = new List<int>();
            HashSet<int> userMap = new HashSet<int>();
            for(int i=0; i <= user.Friends.Count; i++)
            {
                int depth = 0;
                foreach(UserNode friend in user.Friends)
                {
                    Console.WriteLine($"|depth: {depth} -> {friend.FirstName} {friend.LastName} (friends: {friend.Friends.Count})");
                    if(depth == 0)
                    {
                        queue.Enqueue(friend);
                    }
                    depth++;
                    Console.WriteLine("->");
                    foreach(UserNode friendOfFriend in friend.Friends)
                    {
                        Console.WriteLine($"-> |depth: {depth} -> {friendOfFriend.FirstName} {friendOfFriend.LastName} (friends: {friendOfFriend.Friends.Count})");
                    }
                }
                depthDistance.Add(depth);
            }
        }

        public static int MinDistance(UserNode user, UserNode user2)
        {
            return 0;
        }

        public static void ShortestDistance()
        {

        }
    }
}
