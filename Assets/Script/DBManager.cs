using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
   public static string username;
   public static int score;
   public static int level;
   public static bool LoggeIn {get {return username != null;}}
   public static void LogOut()
   {
       username = null;
   }
}
