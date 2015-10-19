using System;
using System.Numerics;
using System.Text;

namespace Converter
{
    class NumeralSystem
    {
        public static string DefaultAlphabet
        {
            get { return "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя"; }
        }

        private string _alphabet;
        public string Alphabet
        {
            get { return _alphabet; }
        }

        private int _maxSystem;
        public int MaxSystem
        {
            get { return this._maxSystem; }
        }

        public NumeralSystem() : this(DefaultAlphabet) { }
        public NumeralSystem(string alphabet)
        {
            this._alphabet = alphabet;
            this._maxSystem = _alphabet.Length;
        }

        public BigInteger systemToDecimal(string num, int sys)
        {
            BigInteger res = 0;
            for (int i = 0; i < num.Length; i++)
            {
                int digit = this._alphabet.IndexOf(num[i]);
                double pow = Math.Pow(sys, num.Length - i - 1);
                res += (BigInteger)(digit * pow);
            }
            return res;
        }

        private string _decimalToSystem(BigInteger num, int sys)
        {
            StringBuilder strBuild=new StringBuilder();
            if (num == 0) strBuild.Append('0');
            while (num != 0)
            {
                BigInteger digit = num % sys;
                strBuild.Append(this._alphabet[(int) digit]);
                num = num / sys;
            }

            int lengthStr = strBuild.Length;
            for (int i = 0; i < lengthStr / 2; i++)
            {
                char tmp = strBuild[i];
                strBuild[i] = strBuild[lengthStr-i-1];
                strBuild[lengthStr - i - 1] = tmp;
            }
            return strBuild.ToString();
        }

        public string decimalToSystem(BigInteger num, int sys)
        {
            if (sys > this._maxSystem) throw new IndexOutOfRangeException();
            return _decimalToSystem(num, sys);
        }

        public string decimalToSystem(string num, int sys)
        {
            return decimalToSystem(BigInteger.Parse(num), sys);
        }

        public string decimalToSystem(int num, int sys)
        {
            return decimalToSystem((BigInteger)num, sys);
        }

        public string decimalToSystem(long num, int sys)
        {
            return decimalToSystem((BigInteger)num, sys);
        }

        public string fromSysToSys(string num, int sys1, int sys2)
        {
            return decimalToSystem(systemToDecimal(num, sys1), sys2);
        }

        public int getMinSystemToNum(string num)
        {
            int system = 1;
            for (int i=0; i<num.Length; i++)
            {
                int sys = _alphabet.IndexOf(num[i]);
                if (sys > system) system = sys;
            }
            return system+1;
        }
        
        public bool alphabetContainDigit(char sym)
        {
            return this._alphabet.IndexOf(sym) != -1;
        }
    }
}
