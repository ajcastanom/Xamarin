using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Database.Sqlite;
using Android.Database;
using AccenturePeople.android.DataBase.Entities;
using System.Collections;
using AccenturePeoplePCL.Models;
using System.Collections.Generic;
using System.IO;

namespace AccenturePeople.android.DataBase
{
    [Activity(Label = "DataBaseManager")]
    class DataBaseManager : SQLiteOpenHelper
    {
        private static String DATABASE_NAME = "AccenturePeople.db";

        public DataBaseManager(Context context) : base(context, DATABASE_NAME, null, 2)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(ContactEntity.CREATE_TABLE_CONTACT);
            db.ExecSQL(LoginRemember.CREATE_TABLE_LOGIN_REMEMBER);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            /*db.ExecSQL("DROP TABLE IF EXISTS " + ContactEntity.CONTACT_TABLE_NAME);
            OnCreate(db);*/
        }

        public bool InsertContact(Contact contact)
        {
            try
            {
                if (ExistEmail(contact.Email))
                {
                    return false;
                } else
                {
                    SQLiteDatabase db = this.WritableDatabase;
                    //db.ExecSQL("DELETE FROM " + ContactEntity.CONTACT_TABLE_NAME);
                    ContentValues contentValues = new ContentValues();
                    contentValues.Put(ContactEntity.CONTACT_EMAIL, contact.Email);
                    contentValues.Put(ContactEntity.CONTACT_PASSWORD, contact.Password);
                    db.Insert(ContactEntity.CONTACT_TABLE_NAME, null, contentValues);
                    db.Close();
                    return true;
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                //db.ExecSQL("DELETE FROM " + ContactEntity.CONTACT_TABLE_NAME);
                ContentValues contentValues = new ContentValues();
                contentValues.Put(ContactEntity.CONTACT_IDENTIFICATION, contact.Identification);
                contentValues.Put(ContactEntity.CONTACT_FIRSTNAME, contact.Firstname);
                contentValues.Put(ContactEntity.CONTACT_LASTNAME, contact.LastName);
                contentValues.Put(ContactEntity.CONTACT_PROJECT, contact.Project);
                contentValues.Put(ContactEntity.CONTACT_PROFESIONAL_PROFILE, contact.ProfessionalProfile);
                contentValues.Put(ContactEntity.CONTACT_LOCATION, contact.Location);
                contentValues.Put(ContactEntity.CONTACT_WBS, contact.Wbs);
                contentValues.Put(ContactEntity.CONTACT_IMAGE, contact.Image);
                db.Update(ContactEntity.CONTACT_TABLE_NAME, contentValues, "email='" + contact.Email + "'", null);
                db.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Contact> GetContacts()
        {
            try
            {
                SQLiteDatabase db = this.ReadableDatabase;
                List<Contact> arrayList = new List<Contact>();
                ICursor res = db.RawQuery("SELECT * FROM " + ContactEntity.CONTACT_TABLE_NAME, null);
                res.MoveToFirst();
                while(res.IsAfterLast == false)
                {
                    arrayList.Add(new Contact(res.GetLong(res.GetColumnIndex(ContactEntity.CONTACT_IDENTIFICATION)), res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_FIRSTNAME)),
                        res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_LASTNAME)), res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_EMAIL)),
                        res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_PROJECT)), res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_PROJECT)), 
                        res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_WBS)), res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_PROFESIONAL_PROFILE)), 
                        res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_LOCATION)), res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_IMAGE))));

                    res.MoveToNext();
                }

                db.Close();
                return arrayList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsLogin(Contact contact)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ArrayList arrayList = new ArrayList();
            ICursor res = db.RawQuery("SELECT * FROM " + ContactEntity.CONTACT_TABLE_NAME + 
                " WHERE email='" + contact.Email + "'", null);
            res.MoveToFirst();
            String password;
            bool isValid = false;
            while (res.IsAfterLast == false)
            {
                password = res.GetString(res.GetColumnIndex(ContactEntity.CONTACT_PASSWORD));
                if (password.Equals(contact.Password))
                {
                    isValid = true;
                }
                res.MoveToNext();
            }

            db.Close();
            return isValid;
        }

        private bool ExistEmail(String email)
        {
            SQLiteDatabase db = this.ReadableDatabase;
            ArrayList arrayList = new ArrayList();
            ICursor res = db.RawQuery("SELECT * FROM " + ContactEntity.CONTACT_TABLE_NAME +
                " WHERE email='" + email + "'", null);
            res.MoveToFirst();
            bool isValid = false;
            while (res.IsAfterLast == false)
            {
                isValid = true;
                break;
            }

            db.Close();
            return isValid;
        }

        /***************************************************************
         ***      METODOS PARA CONSULTAR TABLA LOGIN_REMEMBER        ***
         ***************************************************************/

        public bool InsertLoginRemember(String username, String password, short isRemember)
        {
            try
            {
                SQLiteDatabase db = this.WritableDatabase;
                db.ExecSQL("DELETE FROM " + LoginRemember.LOGIN_REMEMBER_TABLE_NAME);
                ContentValues contentValues = new ContentValues();
                contentValues.Put(LoginRemember.LOGIN_REMEMBER_USERNAME, username);
                contentValues.Put(LoginRemember.LOGIN_REMEMBER_PASSWORD, password);
                contentValues.Put(LoginRemember.LOGIN_REMEMBER_IS_REMEMBER, isRemember);
                db.Insert(LoginRemember.LOGIN_REMEMBER_TABLE_NAME, null, contentValues);
                db.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetLoginRemember()
        {
            try
            {
                SQLiteDatabase db = this.ReadableDatabase;
                List<Contact> arrayList = new List<Contact>();
                ICursor res = db.RawQuery("SELECT * FROM " + LoginRemember.LOGIN_REMEMBER_TABLE_NAME, null);
                res.MoveToFirst();
                string credentials = "{}";
                while (res.IsAfterLast == false)
                {
                    credentials = "{";
                    credentials += "'username': '" + res.GetString(res.GetColumnIndex(LoginRemember.LOGIN_REMEMBER_USERNAME)) + "'";
                    credentials += ",'password': '" + res.GetString(res.GetColumnIndex(LoginRemember.LOGIN_REMEMBER_PASSWORD)) + "'";
                    credentials += ",'is_remember': " + res.GetString(res.GetColumnIndex(LoginRemember.LOGIN_REMEMBER_IS_REMEMBER)) + "";
                    credentials += "}";
                    res.MoveToNext();
                }

                db.Close();
                return credentials;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}