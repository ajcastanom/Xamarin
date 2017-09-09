using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Database.Sqlite;
using Android.Database;
using ContactAccentureAndroid.DataBase.Entities;
using System.Collections;

namespace ContactAccentureAndroid.DataBase
{
    [Activity(Label = "DataBaseManager")]
    class DataBaseManager : SQLiteOpenHelper
    {
        private static String DATABASE_NAME = "ContactAccenture.db";

        public DataBaseManager(Context context) : base(context, DATABASE_NAME, null, 2)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(User.CREATE_TABLE_USER);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS " + User.USER_TABLE_NAME);
            OnCreate(db);
        }

        public bool insertUser(String email)
        {
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                db.ExecSQL("DELETE FROM " + User.USER_TABLE_NAME);
                ContentValues contentValues = new ContentValues();
                contentValues.Put(User.USER_EMAIL, email);
                db.Insert(User.USER_TABLE_NAME, null, contentValues);
                db.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public ArrayList getUser()
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ArrayList arrayList = new ArrayList();
            ICursor res = db.RawQuery("SELECT * FROM " + User.USER_TABLE_NAME, null);
            res.MoveToFirst();

            while(res.IsAfterLast == false)
            {
                arrayList.Add(res.GetString(res.GetColumnIndex(User.USER_EMAIL)));
                res.MoveToNext();
            }

            db.Close();
            return arrayList;
        }
    }
}