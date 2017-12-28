using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BudgetManager
{
    public static class IO
    {
        public static void Save(this Model model, string path)
        {
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, model);
            }
        }

        public static Model Load(this Model model, string path)
        {
            var result = default(Model);
            var formatter = new BinaryFormatter();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                try
                {
                    result = (Model)formatter.Deserialize(stream);
                }
                catch
                {
                    MessageBox.Show("Öffnen fehlgeschlagen!");
                }
            }

            return result;
        }
    }
}
