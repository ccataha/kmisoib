using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KMiSOIB_lab
{
    /// <summary>
    /// Логика взаимодействия для Lab2.xaml
    /// </summary>
    public partial class Lab2 : Window
    {
        public Lab2()
        {
            InitializeComponent();
        }

        private void Task1()
        {
            char[] message = Message1TB.Text.ToCharArray();
            char[] key = Key1TB.Text.ToCharArray();
            int len = message.Length;
            char[] encryptedMsg = new char[len];
            char[] decryptedMsg = new char[len];

            for (int i = 0; i < len; i++) encryptedMsg[i] = (char)(message[i] ^ key[i]);
            for (int i = 0; i < len; i++) decryptedMsg[i] = (char)(encryptedMsg[i] ^ key[i]);

            Encrypted1TB.Text = string.Join("", encryptedMsg);
            Decrypted1TB.Text = string.Join("", decryptedMsg);
        }
        private void Task2()
        {
            string message = Message2TB.Text;
            string key = Key2TB.Text;
            string encryptedMsg = "";
            string decryptedMsg = "";

            int leftBorder = 'а';
            int rightBorder = 'я';
            int size = rightBorder - leftBorder + 1;

            for (int i = 0; i < message.Length; i++)
            {
                if (!char.IsLetter(message[i]))
                {
                    encryptedMsg += message[i];
                    continue;
                }
                int m = char.ToLower(message[i]) % size;
                int k = char.ToLower(key[i]) % size;
                char newChar = (char)((m + k) % leftBorder % size + leftBorder);
                if (char.IsUpper(message[i])) newChar = char.ToUpper(newChar);
                encryptedMsg += newChar;
            }

            for (int i = 0; i < encryptedMsg.Length; i++)
            {
                if (!char.IsLetter(encryptedMsg[i]))
                {
                    decryptedMsg += encryptedMsg[i];
                    continue;
                }

                int m = char.ToLower(encryptedMsg[i]) % size;
                int k = char.ToLower(key[i]) % size;
                char newChar = (char)((m - k) % leftBorder % size + leftBorder);
                decryptedMsg += char.ToLower(newChar);
            }

            Encrypted2TB.Text = encryptedMsg;
            Decrypted2TB.Text = decryptedMsg;
        }
        private void Task3()
        {
            string message = Message3TB.Text;
            int[] key = Key3TB.Text.Split(' ').Select(e => int.Parse(e)).ToArray();
            int len = message.Length;
            char[] encryptedMsg = new char[len];
            char[] decryptedMsg = new char[len];

            for (int i = 0; i < len; i++) encryptedMsg[i] = (char)(message[i] ^ key[i]);
            for (int i = 0; i < len; i++) decryptedMsg[i] = (char)(encryptedMsg[i] ^ key[i]);

            Encrypted3TB.Text = string.Join("", encryptedMsg);
            Decrypted3TB.Text = string.Join("", decryptedMsg);
        }

        private void Proceed1_Button_Click(object sender, RoutedEventArgs e) { Task1(); }
        private void Proceed2_Button_Click(object sender, RoutedEventArgs e) { Task2(); }
        private void Proceed3_Button_Click(object sender, RoutedEventArgs e) { Task3(); }
    }
}
