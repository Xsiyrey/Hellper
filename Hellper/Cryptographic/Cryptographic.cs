using Hellper;
using Hellper.Numbers;
using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace Hellper.Cryptographic
{
    public class ElGamalWorker
    {
        private BigInteger p;
        private BigInteger g;
        private BigInteger x;
        private BigInteger y;
        private BigInteger k;
        private string a;
        private string b;

        public BigInteger P { get => p; set => p = value; }
        public BigInteger G { get => g; set => g = value; }
        public BigInteger X { get => x; set => x = value; }
        public BigInteger Y { get => y; set => y = value; }
        public BigInteger K { get => k; set => k = value; }
        public string A { get => a; set => a = value; }
        public string B { get => b; set => b = value; }

        public ElGamalWorker(BigInteger p, BigInteger g, Random random)
        {
            this.p = p;
            this.g = g;
            GenerateElements(random);
        }
        public ElGamalWorker(int maxValue, Random random)
        {
            if (maxValue < 100)
                maxValue = 100;
            while (!SimpleNumberWorker.IsPrime(p))
                p = random.Next(33, maxValue);
            g = SimpleNumberWorker.FindPrimitive(p);
            GenerateElements(random);
        }

        public ElGamalWorker(BigInteger p, BigInteger g, BigInteger x, BigInteger y, BigInteger k)
        {
            this.p = p;
            this.g = g;
            this.x = x;
            this.y = y;
            this.k = k;
        }

        public void Encrypt(string message, string alphabetName)
        {
            if (message != null)
            {
                a = string.Empty;
                b = string.Empty;
                Type t = typeof(Alphabet.Alphabet);
                FieldInfo field;
                try
                {
                    field = t.GetField(alphabetName);

                }
                catch (Exception)
                {
                    return;
                }

                if (field != null)
                {
                    string alphabet = (string)field.GetValue(null);
                    for (int i = 0; i < message.Length; i++)
                    {
                        if (alphabet.Contains(message[i]))
                        {
                            int index = alphabet.Select((x, ind) => new { element = x, index = ind }).First(y => y.element == message[i]).index + 1;
                            a += BigInteger.ModPow(g, k, p) + " ";
                            b += BigInteger.ModPow(BigInteger.Pow(y, (int)k) * index, 1, p) + " ";
                        }
                    }
                }
                using (StreamWriter stream = new StreamWriter("Encript.txt", false))
                {
                    stream.WriteLine(a);
                    stream.WriteLine(b);
                    stream.WriteLine(ToString());
                }
            }
        }

        public string UnEncrypt(string alphabetName)
        {
            string str = string.Empty;
            Type t = typeof(Alphabet.Alphabet);
            FieldInfo field;
            try
            {
                field = t.GetField(alphabetName);
            }
            catch (Exception)
            {
                return "";
            }

            if (a != string.Empty && b != string.Empty && field != null)
            {
                string alphabet = (string)field.GetValue(null);
                string[] encriptA = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] encriptB = b.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (encriptA.Length == encriptB.Length)
                {
                    for (int i = 0, length = encriptA.Length; i < length; i++)
                    {
                        str += alphabet[(int)BigInteger.ModPow(BigInteger.Parse(encriptB[i]) * BigInteger.Pow(BigInteger.Parse(encriptA[i]), (int)(p - 1 - x)), 1, p) - 1];
                    }
                }
            }
            return str;
        }

        public string Uncrypt(string a, string b, string alphabetName)
        {
            string str = string.Empty;
            Type t = typeof(Alphabet.Alphabet);
            FieldInfo field;
            try
            {
                field = t.GetField(alphabetName);
            }
            catch (Exception)
            {
                return "";
            }

            if (a != string.Empty && b != string.Empty && field != null)
            {
                string alphabet = (string)field.GetValue(null);
                string[] encriptA = a.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string[] encriptB = b.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (encriptA.Length == encriptB.Length)
                {
                    for (int i = 0, length = encriptA.Length; i < length; i++)
                    {
                        str += alphabet[(int)BigInteger.ModPow(BigInteger.Parse(encriptB[i]) * BigInteger.Pow(BigInteger.Parse(encriptA[i]), (int)(p - 1 - x)), 1, p) - 1];
                    }
                }
            }
            return str;
        }

        public override string ToString()
        {
            return $"{p} {g} {x} {y} {k}";
        }

        private void GenerateElements(Random random)
        {
            SetX(random);
            SetY();
            SetK(random);
        }

        private void SetX(Random random)
        {
            x = 2;
            while (!SimpleNumberWorker.IsPrime(x))
                x = random.Next(2, (int)p - 1);
        }

        private void SetY()
        {
            y = BigInteger.ModPow(g, x, p);
        }
        private void SetK(Random random)
        {
            k = 2;
            while (!SimpleNumberWorker.IsMutuallyPrimary(k, p - 1))
                k = random.Next(2, (int)p - 1);
        }

        //static explicit operator object(object element)
        //{

        //    return;
        //}
        //static implicit operator object(object element)
        //{
        //    return;
        //}
    }
    public class BackpackWorker
    {
        BigInteger[] k;
        BigInteger[] openK;
        BigInteger m;
        BigInteger n;
        BigInteger n1;
        BigInteger[] c;

        public BackpackWorker()
        {
            k = SimpleNumberWorker.SupperUpperElements(8);
            m = k.SumOfBigInt() + 4;
            n = 2;
            SetN1();
            while (SimpleNumberWorker.IsMutuallyPrimary(n, m))
                n++;
            openK = new BigInteger[k.Length];
            for (int i = 0, length = openK.Length; i < length; i++)
            {
                openK[i] = BigInteger.ModPow(k[i] * n, 1, m);
            }
        }
        public BackpackWorker(BigInteger n,BigInteger n1,BigInteger m,BigInteger[] k,BigInteger[] openK)
        {
            if (k.Length != 8 || openK.Length != 8)
                throw new Exception("Keys length mast be = 8");
            this.m = m;
            this.n = n;
            this.n1 = n1;
            this.k = k;
            this.openK = openK;
        }

        public string Encrypt(string message)
        {
            if (message == string.Empty)
                throw new Exception("Message mast be not empty");

            string[] encriptText = new string[message.Length];
            c = new BigInteger[message.Length];
            for (int i = 0, length = message.Length; i < length; i++)
            {
                encriptText[i] = Convert.ToString((int)message[i]-848,2).PadRight(8, '0');
                BigInteger sum = 0;
                for (int j = 0; j < encriptText[i].Length; j++)
                {
                    if (encriptText[i][j]=='1')
                    {
                        sum += openK[j];
                    }
                }
                c[i] = sum;
            }
            return /*string.Join(" ", encriptText) + "|" +*/ string.Join(" ",c);
        }
        public string UnEncrypt()
        {
            if (c == null)
                throw new Exception("Encrypt mast not be null");
            string str = string.Empty;
            for (int i = 0; i < c.Length; i++)
            {
                BigInteger element = BigInteger.ModPow(c[i] * n1, 1, m);
                char[] binary = new char[8];
                for (int j = k.Length-1; j >= 0; j--)
                {
                    if (element - k[j] >= 0)
                    {
                        element -= k[j];
                        binary[j] = '1';
                    }
                    else
                    {
                        binary[j] = '0';
                    }
                }
                str += (char)(Convert.ToInt32(string.Join("", binary), 2) + 848);
            }
            return str;
        }
        public string UnEncrypt(params BigInteger[] bigs)
        {
            if (bigs == null)
                throw new Exception("Encrypt mast not be null");
            string str = string.Empty;
            for (int i = 0; i < bigs.Length; i++)
            {
                BigInteger element = BigInteger.ModPow(bigs[i] * n1, 1, m);
                char[] binary = new char[8];
                for (int j = k.Length - 1; j >= 0; j--)
                {
                    if (element - k[j] >= 0)
                    {
                        element -= k[j];
                        binary[j] = '1';
                    }
                    else
                    {
                        binary[j] = '0';
                    }
                }
                str += (char)(Convert.ToInt32(string.Join("", binary), 2) + 848);
            }
            return str;
        }
        private void SetN1()
        {
            n1 = 0;
            while (!N1Validate(n1))
                n1++;
        }
        private bool N1Validate(BigInteger n1)
        {
            return BigInteger.ModPow(n * n1, 1, m) == 1;
        }
        public override string ToString()
        {
            return $"{m} {n} {n1}";
        }
    }
}