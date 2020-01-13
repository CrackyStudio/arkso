using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace ARKSO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
        }

        /// <summary>
        /// Tells the program that the Assembly its Seeking is located in the Embedded resources
        /// </summary>
        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            try
            {
                Assembly parentAssembly = Assembly.GetExecutingAssembly();
                string finalname = args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll";
                string[] ResourcesList = parentAssembly.GetManifestResourceNames();
                string OurResourceName = null;

                for (int i = 0; i <= ResourcesList.Length - 1; i++)
                {
                    string name = ResourcesList[i];

                    if (name.EndsWith(finalname))
                    {
                        OurResourceName = name;
                        break;
                    }
                }

                if (!string.IsNullOrWhiteSpace(OurResourceName))
                {
                    using (Stream stream = parentAssembly.GetManifestResourceStream(OurResourceName))
                    {
                        byte[] block = new byte[stream.Length];
                        stream.Read(block, 0, block.Length);
                        return Assembly.Load(block);
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
