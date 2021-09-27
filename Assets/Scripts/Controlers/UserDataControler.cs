using System;
using System.IO;
using System.Xml.Serialization;
using Models;
using UnityEngine;

namespace Controlers
{
    public class UserDataControler
    {
        #if !UNITY_EDITOR
               string androidPath = Application.persistentDataPath + "/";
        #endif
        
        #if UNITY_EDITOR
                string androidPath = "";
        #endif
        public UserDataModel LoadData()
        {
            UserDataModel userData;
            XmlSerializer formatter = new XmlSerializer(typeof(UserDataModel));

            try
            {
                using(FileStream fs = new FileStream($"{androidPath}persons.xml", FileMode.OpenOrCreate))
                {
                    userData = (UserDataModel) formatter.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                using (FileStream fs = new FileStream($"{androidPath}persons.xml", FileMode.OpenOrCreate))
                {
                    UserDataModel newUserDataModel = new UserDataModel();
                    userData = newUserDataModel;
                    formatter.Serialize(fs, newUserDataModel);
                }
            } 

            return userData;
        }

        public bool SaveData(UserDataModel userDataModel)
        {
            // объект для сериализации
            UserDataModel userData = userDataModel;
            Console.WriteLine("Объект создан");
 
            // передаем в конструктор тип класса
            XmlSerializer formatter = new XmlSerializer(typeof(UserDataModel));
 
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream($"{androidPath}persons.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, userData);
 
                Console.WriteLine("Объект сериализован");
            }

            return true;
        }
    }
}