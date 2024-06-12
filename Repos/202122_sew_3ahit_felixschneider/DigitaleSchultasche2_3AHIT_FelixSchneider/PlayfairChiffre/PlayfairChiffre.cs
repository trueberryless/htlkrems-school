using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayfairChiffre
{
    public class PlayfairChiffre
    {
        private string? password;
        private char[,]? table;

        public PlayfairChiffre(string passwd)
        {
            SetPassword(passwd);
        }

        public PlayfairChiffre() :this ("Password") { }

        public void SetPassword(string passwd)
        {
            if(passwd != null)
            {
                passwd = passwd.ToUpper();
                passwd = RemoveNonStrings(passwd);
                this.password = passwd;
            }
            this.table = new char[5, 5];
            SetTable();
        }

        private void SetTable()
        {
            char active = 'A';
            int active_passwd_letter = 0;

            // 2 For-Schleifen für Tabelle (horizontal und vertikal)
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++) 
                {
                    // In Schlüsselphase soll Schlüssel in Tabelle geschrieben werden
                    if(active_passwd_letter < password.Length)
                    {
                        active = char.Parse(password.Substring(active_passwd_letter, 1));
                        active_passwd_letter++;
                    }
                    // In "Nicht-Schlüsselphase" soll Alphabet aufgefüllt werden
                    else if(active_passwd_letter == password.Length)
                    {
                        active = 'A';
                        active_passwd_letter++;
                    }


                    // Überprüfung ob Buchstabe bereits vorkommt oder j,
                    // wenn ja, active++, aber j bleibt gleich, damit in gleicher Zelle
                    if (Letter_already_exists(active))
                    {
                        j--;
                        active++;
                        continue;
                    }

                    // aktiv errechneten Buchstaben in Zelle schreiben
                    table[i, j] = active;

                    // active erhöhen, damit das Alphabet weitergeht
                    active++;
                }
            }
        }

        private bool Letter_already_exists(char active)
        {
            for (int k = 0; k < table.GetLength(0); k++)
            {
                for (int l = 0; l < table.GetLength(1); l++)
                {
                    if (active == table[k, l] || active == 'J')
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string Encryption(string msg)
        {
            string[] division = Encryption_Division(msg.ToUpper());
            return Encryption_Calculation(division);
        }

        private string[] Encryption_Division(string msg)
        {
            msg = RemoveNonStrings(msg);

            for (int i = 0; i <= msg.Length; i+=2)
            {
                try
                {
                    if (msg[i] == msg[i + 1])
                        msg = msg.Insert(i + 1, "X");
                }
                catch { }
            }

            if (msg.Length % 2 == 1)
                msg = msg.Insert(msg.Length, "X");

            for (int i = 2; i < msg.Length; i+=3)
            {
                msg = msg.Insert(i, "-");
            }

            string[] division = msg.Split('-');

            return division;
        }

        private string Encryption_Calculation(string[] division)
        {
            string[] code = division;

            for (int i = 0; i < division.Length; i++)
            {
                string item = division[i];
                // Letter One X-Position, ...
                int l1x  = -1, l1y = -2, l2x = -3, l2y = -4;
                for (int j = 0; j < table.GetLength(0); j++)
                {
                    // Buchstaben suchen
                    for (int k = 0; k < table.GetLength(1); k++)
                    {
                        if(table[j, k] == char.Parse(item.Substring(0, 1)))
                        {
                            l1x = k;
                            l1y = j;
                        }
                        if (table[j, k] == char.Parse(item.Substring(1, 1)))
                        {
                            l2x = k;
                            l2y = j;
                        }
                    }
                }

                // neue Buchstaben schreiben, je nach Fall
                code[i] = "";

                if (l1y == l2y)
                {
                    if (l1x + 1 < 5)
                        code[i] += table[l1y, l1x + 1];
                    else code[i] += table[l1y, 0];

                    if (l2x + 1 < 5)
                        code[i] += table[l2y, l2x + 1];
                    else code[i] += table[l2y, 0];
                }
                else if (l1x == l2x)
                {
                    if (l1y + 1 < 5)
                        code[i] += table[l1y + 1, l1x];
                    else code[i] += table[0, l1x];

                    if (l2y + 1 < 5)
                        code[i] += table[l2y + 1, l2x];
                    else code[i] += table[0, l2x];
                }
                else
                {
                    code[i] += table[l1y, l2x];
                    code[i] += table[l2y, l1x];
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in code)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        public string Decryption(string code)
        {
            string[] division = Decryption_Division(code.ToUpper());
            return Decryption_Calculation(division);
        }

        private string[] Decryption_Division(string msg)
        {
            for (int i = 2; i < msg.Length; i += 3)
            {
                msg = msg.Insert(i, "-");
            }

            string[] division = msg.Split('-');

            return division;
        }

        private string Decryption_Calculation(string[] division)
        {
            string[] code = division;

            for (int i = 0; i < division.Length; i++)
            {
                string item = division[i];
                // Letter One X-Position, ...
                int l1x = -1, l1y = -2, l2x = -3, l2y = -4;
                for (int j = 0; j < table.GetLength(0); j++)
                {
                    // Buchstaben suchen
                    for (int k = 0; k < table.GetLength(1); k++)
                    {
                        if (table[j, k] == char.Parse(item.Substring(0, 1)))
                        {
                            l1x = k;
                            l1y = j;
                        }
                        if (table[j, k] == char.Parse(item.Substring(1, 1)))
                        {
                            l2x = k;
                            l2y = j;
                        }
                    }
                }

                // neue Buchstaben schreiben, je nach Fall
                code[i] = "";

                if (l1y == l2y)
                {
                    if (l1x - 1 >= 0)
                        code[i] += table[l1y, l1x - 1];
                    else code[i] += table[l1y, 4];

                    if (l2x - 1 >= 0)
                        code[i] += table[l2y, l2x - 1];
                    else code[i] += table[l2y, 4];
                }
                else if (l1x == l2x)
                {
                    if (l1y - 1 >= 0)
                        code[i] += table[l1y - 1, l1x];
                    else code[i] += table[4, l1x];

                    if (l2y - 1 >= 0)
                        code[i] += table[l2y - 1, l2x];
                    else code[i] += table[4, l2x];
                }
                else
                {
                    code[i] += table[l1y, l2x];
                    code[i] += table[l2y, l1x];
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in code)
            {
                sb.Append(item);
            }
            return sb.ToString();
        }

        private string RemoveNonStrings(string value)
        {
            string nonstrings = " !\"§$%&/()=\\²³{[]}+*~#´'+-_.:,;<>|^°0123456789";
            foreach (char c in nonstrings)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value.Substring(i, 1) == c.ToString())
                        value = value.Remove(i, 1);
                }
            }

            for (int i = 0; i < value.Length; i++)
            {
                if (value.Substring(i, 1) == "Ü")
                {
                    value = value.Remove(i, 1);
                    value = value.Insert(i, "UE");
                }
                if (value.Substring(i, 1) == "Ö")
                {
                    value = value.Remove(i, 1);
                    value = value.Insert(i, "OE");
                }
                if (value.Substring(i, 1) == "Ä")
                {
                    value = value.Remove(i, 1);
                    value = value.Insert(i, "AE");
                }
            }

            return value;
        }
    }
}
