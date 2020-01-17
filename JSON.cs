using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ARKSO
{
    class Json
    {
        public static string serverJson = Path.Combine(MainWindow.confPath, "server.json");
        public static string mapsJson = Path.Combine(MainWindow.confPath, "maps.json");
        public static string VACJson = Path.Combine(MainWindow.confPath, "vac.json");
        public static string BattlEyeJson = Path.Combine(MainWindow.confPath, "battleye.json");

        /// <summary>
        /// Create properties
        /// </summary>
        public static void Create()
        {
            try
            {
                Save(serverJson, Objects.server);
                Save(mapsJson, Objects.maps);
                Save(VACJson, Objects.vac);
                Save(BattlEyeJson, Objects.battleye);
                Utils.Log("Objects successfully created", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log($"{ex.Message}\n{ex.InnerException}", "ERROR");
                Application.Current.Shutdown();
            }       
        }

        /// <summary>
        /// Returns object
        /// </summary>
        public static JObject Read(string path)
        {
            JObject obj = new JObject { };

            try
            {            
                using (StreamReader file = File.OpenText(path))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    obj = (JObject)JToken.ReadFrom(reader);
                }             
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
                Application.Current.Shutdown();
            }

            return obj;
        }


        /// <summary>
        /// Update object
        /// </summary>
        public static void Update(string path, string key, string value)
        {
            /* Block if key doesn't exists */
            /* Add try catch block */
            string json = Read(path).ToString();

            JObject obj = JObject.Parse(json);

            obj[$"{key}"] = $"{value}";

            Save(path, obj);
        }

        /// <summary>
        /// Update object (from control event)
        /// </summary>
        public static void Update(object sender, RoutedEventArgs e)
        {
            var control = (TextBox)sender;
            var controlName = control.Name;
            Update(serverJson, controlName, control.Text);
            if (controlName == "port")
            {
                Graphics.Main.addressLabel.Content = $"{MainWindow.serverIP}:{control.Text}";
            }
        }

        /// <summary>
        /// Save object to json file
        /// </summary>
        public static void Save(string path, JObject obj)
        {
            try
            {
                using (StreamWriter file = File.CreateText(path))
                using (JsonTextWriter writer = new JsonTextWriter(file) { Formatting = Formatting.Indented })
                {
                    obj.WriteTo(writer);
                }
                Utils.Log("Object saved to json file", "OK");
            }
            catch (Exception ex)
            {
                Utils.Log(ex.Message, "ERROR");
            }           
        }

        /// <summary>
        /// Returns specified key value from object
        /// </summary>
        public static string GetProperty(string path, string key)
        {
            JObject obj = Read(path);
            return obj.GetValue(key).ToString();
        }

        /// <summary>
        /// Returns list of all values
        /// </summary>
        public static List<string> GetKeys(string path)
        {
            List<string> mapList = new List<string> { };
            JObject json = Read(path);
            foreach (var item in json)
            {
                mapList.Add(item.Key.ToString());
            }
            return mapList;
        }

        /// <summary>
        /// Returns index of selected server property
        /// </summary>
        public static int GetSelectedIndexProperty(string searchedKey, JObject refObject)
        {
            string keyValue = Read(serverJson)[searchedKey].ToString();
            string key = "";
            foreach (var item in refObject)
            {
                if (item.Value.ToString() == keyValue)
                {
                    key = item.Key;
                }
            }
            List<string> list = new List<string> { };

            foreach (var item in refObject)
            {
                list.Add(item.Key.ToString());             
            }

            return list.IndexOf(key);
        }

        /// <summary>
        /// Update Map combobox value
        /// </summary>
        public static void UpdateMap(object sender, RoutedEventArgs e)
        {
            var control = (ComboBox)sender;
            var controlName = control.Name;
            Update(serverJson, controlName, GetProperty(mapsJson, control.SelectedValue.ToString()));
        }

        /// <summary>
        /// Update VAC combobox value
        /// </summary>
        public static void UpdateVAC(object sender, RoutedEventArgs e)
        {
            var control = (ComboBox)sender;
            var controlName = control.Name;
            Update(serverJson, controlName, GetProperty(VACJson, control.SelectedValue.ToString()));
        }

        /// <summary>
        /// Update BattlEye combobox value
        /// </summary>
        public static void UpdateBattlEye(object sender, RoutedEventArgs e)
        {
            var control = (ComboBox)sender;
            var controlName = control.Name;
            Update(serverJson, controlName, GetProperty(BattlEyeJson, control.SelectedValue.ToString()));
        }

        /// <summary>
        /// Return JObject json after parsing string
        /// </summary>
        public static JObject ParseString(string str)
        {
            return JObject.Parse(str);
        }

        /// <summary>
        /// Check if Json contains all required fields
        /// </summary>
        public static void IsJsonIso()
        {
            JObject serverConf = Read(serverJson);
            string[] keys = { "name", "map", "players", "vac", "battleye", "password", "admin_password", "port", "query_port", "arguments", "options", "hide_console", "auto_unb" };
            foreach (string key in keys)
            {
                if (!serverConf.ContainsKey(key))
                {
                    if (key == "hide_console" || key == "auto_unb")
                    {
                        Update(serverJson, key, "False");
                    } else
                    {
                        Update(serverJson, key, "");
                    }                
                }
            }
        }
    }
}
