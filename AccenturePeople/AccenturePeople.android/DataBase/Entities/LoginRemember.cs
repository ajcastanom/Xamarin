using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AccenturePeople.android.DataBase.Entities
{
    public static class LoginRemember
    {
        public static string LOGIN_REMEMBER_TABLE_NAME = "LOGIN_REMEMBER";

        public static string LOGIN_REMEMBER_ID = "id";
        public static string LOGIN_REMEMBER_USERNAME = "username";
        public static string LOGIN_REMEMBER_PASSWORD = "password";
        public static string LOGIN_REMEMBER_IS_REMEMBER = "is_remember";

        public static string CREATE_TABLE_LOGIN_REMEMBER = "CREATE TABLE IF NOT EXISTS " +
            LoginRemember.LOGIN_REMEMBER_TABLE_NAME + " " +
            "(" + LoginRemember.LOGIN_REMEMBER_ID + " integer primary key, " +
                  LoginRemember.LOGIN_REMEMBER_USERNAME + " text, " +
                  LoginRemember.LOGIN_REMEMBER_PASSWORD + " text, " +
                  LoginRemember.LOGIN_REMEMBER_IS_REMEMBER + " integer);";
    }
}