using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
    public partial class Lab4 : Window
    {
        public Lab4()
        {
            InitializeComponent();
            MessageTB.CharacterCasing = CharacterCasing.Upper;
        }

        private void RraTB_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBox(nTB, phiTB, eTB, PublicKeyTB, PrivateKeyTB, EncryptedTB, DecryptTB);

            RSA rsa = new RSA(MessageTB.Text, int.Parse(pTB.Text), int.Parse(qTB.Text), int.Parse(dTB.Text), int.Parse(kTB.Text));
            nTB.Text = rsa.n.ToString();
            phiTB.Text = rsa.phi.ToString();
            eTB.Text = rsa.e.ToString();
            PublicKeyTB.Text = rsa.GetPublicKey();
            PrivateKeyTB.Text = rsa.GetPrivateKey();
            EncryptedTB.Text = rsa.Encrypt();
            DecryptTB.Text = rsa.Decrypt();
        }

        private void ClearTextBox(params TextBox[] elements)
        {
            foreach (var e in elements) { e.Clear(); }
        }
    }

    class RSA
    {
        string message, encryptedMessage, decryptedMessage;
        public int p { get; }
        public int q { get; }
        public int d { get; }
        public int k { get; }
        public int n { get; }
        public int phi { get; }
        public int e { get; }

        public RSA(string message, int p, int q, int d, int k)
        {
            this.message = message;
            this.p = p;
            this.q = q;
            this.d = d;
            this.k = k;

            n = p * q;
            phi = (p - 1) * (q - 1);
            e = (phi * k + 1) / d;
        }

        public string GetPublicKey() { return e + " " + n; }
        public string GetPrivateKey() { return d + " " + n; }

        public string Encrypt()
        {
            foreach (var ch in message)
            {
                if (ch == ' ') continue;
                int charIndex = Alphabet.GetCharIndex33(ch);
                var res = BigInteger.ModPow(charIndex, e, n);
                encryptedMessage += res + " ";
            }

            return encryptedMessage;
        }

        public string Decrypt()
        {
            foreach (var ch in encryptedMessage.Trim().Split(' '))
            {
                var res = BigInteger.ModPow(int.Parse(ch), d, n);
                decryptedMessage += Alphabet.GetChar33((int)res);
            }

            return decryptedMessage;
        }

    }
}
