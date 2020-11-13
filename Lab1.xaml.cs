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
    public partial class Lab1 : Window
    {

        public Lab1()
        {
            InitializeComponent();
        }
        private void Task1()
        {
            string message = Message1TB.Text;
            string encryptedMsg = "";
            string decryptedMsg = "";
            int offset = 5;

            for (int i = 0; i < message.Length; i++)
                encryptedMsg += message[(i + offset) % message.Length];

            for (int i = 0; i < message.Length; i++)
                decryptedMsg += encryptedMsg[(i - offset + message.Length) % message.Length];

            Encrypted1TB.Text = encryptedMsg;
            Decrypted1TB.Text = decryptedMsg;
        }

        private void Task2()
        {
            string message = Message2TB.Text;
            char[] table = message.ToCharArray();
            int offset = 18;

            for (int i = 0; i < table.Length; i++)
                table[i] = (char)(table[i] + offset);

            Encrypted2TB.Text = string.Join("", table);

            for (int i = 0; i < table.Length; i++)
                table[i] = (char)(table[i] - offset);

            Decrypted2TB.Text = string.Join("", table);
        }

        private void Task3()
        {
            string message = Message3TB.Text;
            string encryptedMsg = "";
            string decryptedMsg = "";
            int index = 0;

            var dict = new Dictionary<char, int[]>();
            dict.Add('с', new int[] { 7 });
            dict.Add('т', new int[] { 5 });
            dict.Add('а', new int[] { 8, 9 });
            dict.Add('к', new int[] { 4 });
            dict.Add('н', new int[] { 1 });

            foreach (var ch in message)
            {
                int num;
                if (dict[ch].Length > 1) num = dict[ch][index++];
                else num = dict[ch][0];
                encryptedMsg += num + " ";
            }

            foreach (var num in encryptedMsg.Trim().Split(' '))
                decryptedMsg += dict.FirstOrDefault(x => x.Value.Contains(int.Parse(num))).Key;

            Encrypted3TB.Text = encryptedMsg;
            Decrypted3TB.Text = decryptedMsg;
        }

        private void _Task4()
        {
            string message = Message4TB.Text;
           // string encryptedMsh = "";
           // string decryptedMsg = "";

            const int m = 5;
            char[,] matrix = new char[m, m]
            {
                { 'w', 'h', 'e', 'a', 't' },
                { 's', 'o', 'n', 'b', 'c' },
                { 'd', 'f', 'g', 'i', 'k' },
                { 'l', 'm', 'p', 'q', 'r' },
                { 'u', 'v', 'x', 'y', 'z' }
            };

            string tmp = "";

            for (int i = 0; i < message.Length; i += 2)
            {
                for (int j = i; j < i + 2; j++)
                {
                    if (message[j] == ' ')
                    {
                        tmp += 'x';
                        continue;
                    }
                    tmp += message[j];
                }
                //tmp += " ";
            }
            Console.WriteLine(tmp);

            string encrypted = "";
            for (int i = 0; i < tmp.Length - 1; i += 2)
            {
                int[] a = findIndexes(tmp[i]);
                int[] b = findIndexes(tmp[i + 1]);
                int[] c = new int[2];
                int[] d = new int[2];

                if (a[0] == b[0])
                {
                    c[0] = a[0]; c[1] = a[1] + 1;
                    d[0] = b[0]; d[1] = b[1] + 1;
                    encrypted += matrix[c[0], c[1]];
                    encrypted += matrix[d[0], d[1]];
                }
                else if (a[0] - 1 == b[0])
                {
                    c[0] = a[0] - 1; c[1] = a[1];
                    d[0] = b[0] + 1; d[1] = b[1];
                    encrypted += matrix[d[0], d[1]];
                    encrypted += matrix[c[0], c[1]];
                }
                else if (a[1] == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] - 1;
                    d[0] = b[0]; d[1] = b[1] - 1;
                    encrypted += matrix[d[0], d[1]];
                    encrypted += matrix[c[0], c[1]];
                }
                else if (a[1] - 1 == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] - 1;
                    d[0] = b[0]; d[1] = b[1] + 1;
                    encrypted += matrix[c[0], c[1]];
                    encrypted += matrix[d[0], d[1]];
                }
                else if (a[1] + 3 == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] + 1;
                    d[0] = b[0]; d[1] = b[1] - 1;
                    encrypted += matrix[c[0], c[1]];
                    encrypted += matrix[d[0], d[1]];
                }
            }

            string decrypted = "";
            for (int i = 0; i < encrypted.Length - 1; i += 2)
            {
                int[] a = findIndexes(encrypted[i]);
                int[] b = findIndexes(encrypted[i + 1]);
                int[] c = new int[2];
                int[] d = new int[2];

                if (a[0] == b[0])
                {
                    c[0] = a[0]; c[1] = a[1] - 1;
                    d[0] = b[0]; d[1] = b[1] - 1;
                    decrypted += matrix[c[0], c[1]];
                    decrypted += matrix[d[0], d[1]];
                }
                else if (a[0] - 1 == b[0])
                {
                    c[0] = a[0] - 1; c[1] = a[1];
                    d[0] = b[0] + 1; d[1] = b[1];
                    encrypted += matrix[d[0], d[1]];
                    encrypted += matrix[c[0], c[1]];
                   
                }
                else if (a[1] == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] + 1;
                    d[0] = b[0]; d[1] = b[1] + 1;
                    decrypted += matrix[d[0], d[1]];
                    decrypted += matrix[c[0], c[1]];
                }
                else if (a[1] + 1 == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] + 1;
                    d[0] = b[0]; d[1] = b[1] - 1;
                    decrypted += matrix[c[0], c[1]];
                    decrypted += matrix[d[0], d[1]];
                }
                else if (a[1] - 3 == b[1])
                {
                    c[0] = a[0]; c[1] = a[1] - 1;
                    d[0] = b[0]; d[1] = b[1] + 1;
                    decrypted += matrix[c[0], c[1]];
                    decrypted += matrix[d[0], d[1]];
                }

            }

            Console.WriteLine(encrypted);
            Console.WriteLine(decrypted);

            int[] findIndexes(char ch)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] == ch) return new int[] { i, j };
                    }
                }

                return new int[] { -1, -1 };
            }
        }
        private void Task4()
        {
            string message = Message4TB.Text.Replace(' ', 'x');
            string encryptedMsg = "";
            string decryptedMsg = "";
            const int m = 5;
            char[,] matrix = new char[m, m]
            {
                { 'a', 'i', 'e', 'n', 'b' },
                { 'f', 'k', 'd', 'x', 'w' },
                { 'v', 'l', 'c', 'o', 'r' },
                { 'p', 'y', 'f', 't', 'h' },
                { 'q', 'm', 'u', 'g', 's' },
            };

            foreach (var ch in message)
            {
                int[] ind = findIndexes(ch);
                encryptedMsg += matrix[ind[0] + 1, ind[1] + 1];
            }

            foreach (var ch in encryptedMsg)
            {
                int[] ind = findIndexes(ch);
                decryptedMsg += matrix[ind[0] - 1, ind[1] - 1];
            }

            Encrypted4TB.Text = encryptedMsg;
            Decrypted4TB.Text = decryptedMsg;

            int[] findIndexes(char ch)
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] == ch) return new int[] { i, j };
                    }
                }

                return new int[] { -1, -1 };
            }
        }
        private void Task5()
        {
            string message = Message5TB.Text;
            string key = Key5TB.Text;
            string encryptedMsg = "";
            string decryptedMsg = "";

            int leftBorder = 'а';
            int rightBorder = 'я';
            int size = rightBorder - leftBorder + 1;

            for(int i = 0; i < message.Length; i++)
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

            Encrypted5TB.Text = encryptedMsg;
            Decrypted5TB.Text = decryptedMsg;

        }
        private void Task6(int offset)
        {
            string message = Message6TB.Text;
            int leftBorder = 'a';
            int rightBorder = 'z';
            int size = rightBorder - leftBorder + 1;

            string decryptedMsg = "";
            foreach (var ch in message)
            {
                if (!char.IsLetter(ch))
                {
                    decryptedMsg += ch;
                    continue;
                }

                char newChar = (char)((char.ToLower(ch) + offset) % leftBorder % size + leftBorder);
                newChar = char.IsUpper(ch) ? char.ToUpper(newChar) : newChar;
                if (char.IsUpper(ch)) newChar = char.ToUpper(newChar);
                decryptedMsg += newChar;
            }

            Decrypted6TB.Text = decryptedMsg;
        }
        private void Task7()
        {
            int offset = 13;
            string message = Message7TB.Text;
            int leftBorder = 'a';
            int rightBorder = 'z';
            int size = rightBorder - leftBorder + 1;

            string encryptedMsg = "";
            string decryptedMsg = "";

            foreach (var ch in message)
            {
                if (!char.IsLetter(ch))
                {
                    encryptedMsg += ch;
                    continue;
                }

                char newChar = (char)((char.ToLower(ch) + offset) % leftBorder % size + leftBorder);
                newChar = char.IsUpper(ch) ? char.ToUpper(newChar) : newChar;
                if (char.IsUpper(ch)) newChar = char.ToUpper(newChar);
                encryptedMsg += newChar;
            }

            foreach (var ch in encryptedMsg)
            {
                if (!char.IsLetter(ch))
                {
                    decryptedMsg += ch;
                    continue;
                }

                char newChar = (char)((char.ToLower(ch) + offset + size) % leftBorder % size + leftBorder);
                newChar = char.IsUpper(ch) ? char.ToUpper(newChar) : newChar;
                if (char.IsUpper(ch)) newChar = char.ToUpper(newChar);
                decryptedMsg += newChar;
            }

            Encrypted7TB.Text = encryptedMsg;
            Decrypted7TB.Text = decryptedMsg;
        }

        private void Proceed1_Click(object sender, RoutedEventArgs e) { Task1(); }
        private void Proceed2_Click(object sender, RoutedEventArgs e) { Task2(); }
        private void Proceed3_Click(object sender, RoutedEventArgs e) { Task3(); }
        private void Proceed4_Click(object sender, RoutedEventArgs e) { Task4(); }
        private void Proceed5_Click(object sender, RoutedEventArgs e) { Task5(); }
        private void Proceed6_Click(object sender, RoutedEventArgs e)
        {
            int offset = int.Parse(Offset6TB.Text);
            Task6(offset);
        }
        private void Proceed7_Click(object sender, RoutedEventArgs e) { Task7(); }
    }

}
