using System.Windows.Forms;

namespace SecureVault
{
    public static class FileDialogHelper
    {
        public static string SelectFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }

        public static string SaveFile()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            return dialog.ShowDialog() == DialogResult.OK ? dialog.FileName : null;
        }
    }
}