using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinanceMananger.Core;
using System.IO;
using FinanceManager.Gui.Properties;
using System.Windows.Forms;

namespace FinanceManager.Gui
{
    public static class ModelLoader
    {
        public static Model CurrentModel
        {
            get;
            private set;
        }

        private static string ModelPath
        {
            get
            {
                return Path.Combine(Application.StartupPath, Settings.Default.ModelPath);
            }
        }

        public static void LoadModel()
        {
            if (File.Exists(ModelPath))
            {
                CurrentModel = XmlSerialization.DeserializeModel(ModelPath);
            }
            else
            {
                CurrentModel = new Model();

                SaveModel();
            }
        }

        public static void SaveModel()
        {
            XmlSerialization.SerializeModel(CurrentModel, ModelPath);
        }
    }
}
