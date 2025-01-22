using WalletGenerator;
using System;
using System.Windows.Forms;

namespace catwiftools
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new CatWifTools());
        }
    }
}