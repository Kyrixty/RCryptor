using System.IO;
using System.Security.Cryptography;

namespace RCryptorApp
{
    public partial class RCryptor : Form
    {
        private FileInfo fileInfo;
        private string fileName;
        private FileInfo outDirInfo;
        private string AES_KEY = "Why would you want to cheat?... :o It's no fun. :') :'D";
        private int BUF_SIZE = 2048;
        private string RepoSavePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\semiwork\\Repo\\saves";

        public RCryptor()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void copyStream(Stream input, Stream output, int bufSize)
        {
            byte[] buffer = new byte[bufSize];
            int count;
            while ((count = input.Read(buffer, 0, bufSize)) > 0)
            {
                output.Write(buffer, 0, count);
            }
        }

        byte[] Encrypt(byte[] bytes, string password, int bufSize)
        {
            MemoryStream input = new MemoryStream(bytes);
            MemoryStream memoryStream = new MemoryStream();
            _encrypt(input, memoryStream, password, bufSize);
            return memoryStream.ToArray();
        }

        void _encrypt(Stream input, Stream output, string password, int bufSize)
        {
            input.Position = 0L;
            using Aes aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.GenerateIV();
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, aes.IV, 100);
            aes.Key = rfc2898DeriveBytes.GetBytes(16);
            output.Write(aes.IV, 0, 16);
            using ICryptoTransform transform = aes.CreateEncryptor();
            using CryptoStream output2 = new CryptoStream(output, transform, CryptoStreamMode.Write);
            copyStream(input, output2, bufSize);
        }

        byte[] Decrypt(byte[] bytes, string password, int bufSize)
        {
            MemoryStream input = new MemoryStream(bytes);
            MemoryStream output = new MemoryStream();
            _decrypt(input, output, password, bufSize);
            return output.ToArray();
        }

        void _decrypt(Stream input, Stream output, string password, int bufSize)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] array = new byte[16];
                input.Read(array, 0, 16);
                aes.IV = array;
                Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, aes.IV, 100);
                aes.Key = rfc2898DeriveBytes.GetBytes(16);
                using ICryptoTransform transform = aes.CreateDecryptor();
                using CryptoStream input2 = new CryptoStream(input, transform, CryptoStreamMode.Read);
                copyStream(input2, output, bufSize);
            }
            output.Position = 0L;
        }

        private void openFileButtonClick(object _, EventArgs __)
        {
            fileDialog.Filter = "Repo Save Files (*.es3)|*.es3|RCryptor Save Files(*.repo)|*.repo";
            if (Directory.Exists(RepoSavePath))
            {
                fileDialog.InitialDirectory = RepoSavePath;
            }
            if (fileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fileName = fileDialog.SafeFileName;
            fileInfo = new FileInfo(fileDialog.FileName);
            saveFileTextBox.Text = fileInfo.FullName;
        }

        private void openOutFileButtonClick(object _, EventArgs __)
        {
            if (dirDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            outDirInfo = new FileInfo(dirDialog.SelectedPath);
            outputDirTextBox.Text = outDirInfo.FullName;
        }

        private void onEncrypt(object _, EventArgs __)
        {
            string inFp = saveFileTextBox.Text;
            string outFp = outputDirTextBox.Text + "\\" + "out.es3";
            byte[] ifpData = File.ReadAllBytes(inFp);
            byte[] data = Encrypt(ifpData, AES_KEY, BUF_SIZE);
            File.WriteAllBytes(outFp, data);
        }

        private void onDecrypt(object _, EventArgs __)
        {
            string inFp = saveFileTextBox.Text;
            string outFp = outputDirTextBox.Text + "\\" + "out.repo";
            byte[] ifpData = File.ReadAllBytes(inFp);
            byte[] data = Decrypt(ifpData, AES_KEY, BUF_SIZE);
            File.WriteAllBytes(outFp, data);
        }
    }
}
