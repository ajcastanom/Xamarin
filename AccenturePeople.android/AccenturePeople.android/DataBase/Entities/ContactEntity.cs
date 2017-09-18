using System;

namespace AccenturePeople.android.DataBase.Entities
{
    public static class ContactEntity
    {
        public static String CONTACT_TABLE_NAME = "contacts";

        public static String CONTACT_ID = "id";
        public static String CONTACT_IDENTIFICATION = "identification";
        public static String CONTACT_FIRSTNAME = "firstname";
        public static String CONTACT_LASTNAME = "lastname";
        public static String CONTACT_EMAIL = "email";
        public static String CONTACT_PASSWORD = "password";
        public static String CONTACT_PROJECT = "project";
        public static String CONTACT_WBS = "wbs";
        public static String CONTACT_PROFESIONAL_PROFILE = "profesional_profile";
        public static String CONTACT_LOCATION = "location";
        public static String CONTACT_IMAGE = "image";

        public static String CREATE_TABLE_CONTACT = "CREATE TABLE IF NOT EXISTS " +
            ContactEntity.CONTACT_TABLE_NAME + " " +
            "(" + ContactEntity.CONTACT_ID + " integer primary key," + ContactEntity.CONTACT_IDENTIFICATION + " integer," +
                ContactEntity.CONTACT_FIRSTNAME + " text," + ContactEntity.CONTACT_LASTNAME + " text," +
                ContactEntity.CONTACT_EMAIL + " text," + ContactEntity.CONTACT_PASSWORD + " text," +
                ContactEntity.CONTACT_PROJECT + " text," + ContactEntity.CONTACT_WBS + " text," +
                ContactEntity.CONTACT_PROFESIONAL_PROFILE + " text," + ContactEntity.CONTACT_LOCATION + " text," +
                ContactEntity.CONTACT_IMAGE + " text);";
    }
}