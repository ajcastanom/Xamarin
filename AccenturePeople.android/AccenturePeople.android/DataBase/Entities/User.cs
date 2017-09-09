using System;

namespace ContactAccentureAndroid.DataBase.Entities
{
    public static class User
    {
        public static String USER_TABLE_NAME = "users";

        public static String USER_ID = "id";
        public static String USER_EMAIL = "email";

        public static String CREATE_TABLE_USER = "CREATE TABLE IF NOT EXISTS " +
            User.USER_TABLE_NAME + " " +
            "(" + User.USER_ID + "integer primary key," + User.USER_EMAIL + " text);";
    }
}