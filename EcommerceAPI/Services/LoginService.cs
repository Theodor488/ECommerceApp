using ECommerceAPI.Models;
using System;
using System.IO;
using System.Collections;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ECommerceAPI.Services;

// Contains the logic for authenticating the user.
// Compares the hashed password from the database with the input password.
// Handles the hashing, authentication checks, and communication with a database or storage service.

public static class LoginService
{
    static List<User> Users { get; }
    static int nextId = 3;
    static LoginService()
    {
        Users = new List<User>
        {
            new User { Id = 1, Username = "theodor488", Password = "password" },
            new User { Id = 2, Username = "gamer123", Password = "Day123" }
        };
    }

    public static List<User> GetAll() => Users;

    public static User? Get(int id) => Users.FirstOrDefault(p => p.Id == id);

    public static bool AuthenticateLoginCredentials(string input_username, string input_password, User curr_user)
    {
        foreach (User user in Users)
        {
            if (user.Username == input_username)
            {
                if (curr_user.Username == input_username && curr_user.Password == input_password)
                {
                    Console.WriteLine($"Login successful: username: {input_username}, password: {input_password}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Login failed: username: {input_username}, password: {input_password}");
                    return false;
                }
            }
        }

        Console.WriteLine($"username: {input_username} does not exist.");
        return false;
    }

    public static void Add(User user)
    {
        user.Id = nextId++;
        Users.Add(user);
    }

    public static void Delete(int id)
    {
        var user = Get(id);
        if(user is null)
            return;

        Users.Remove(user);
    }

    public static void Update(User user)
    {
        var index = Users.FindIndex(p => p.Id == user.Id);
        if(index == -1)
            return;

        Users[index] = user;
    }
}