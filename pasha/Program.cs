using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pasha
{
    class TextFormatter
    {
        static void Main(string[] args)
        {
            string str = "Не презирай слабого детеныша — он может оказаться сыном тигра, говорит монгольская пословица. Несколько лет провел в рабстве мальчик Темуджин, прежде чем завоевать полмира.";
            TextFormatter textFormatter = new TextFormatter();

            String res = textFormatter.Justify(str, 30);

            Console.Write(res);
            Console.ReadKey();
        }

        public String Justify(String text, int width)
        {
            String[] sublines = text.Split(' ');
            String ResultString = "";

            List<String> FirstStep = new List<String>();

            int currentwidth = 0;
            String buf = "";

            foreach (String s in sublines)
            {
                if (s.Length + currentwidth < width)
                {
                    buf += s + " ";
                    currentwidth += s.Length + 1;
                }
                else
                {
                    if (buf[buf.Length - 1] == ' ')
                    {
                        buf = buf.Substring(0, buf.Length - 1);
                    }

                    FirstStep.Add(buf);
                    buf = s + " ";
                    currentwidth = s.Length;
                }
            }

            if (buf[buf.Length - 1] == ' ')
            {
                buf = buf.Substring(0, buf.Length - 1);
            }

            FirstStep.Add(buf);

            buf = "";

            foreach (String s in FirstStep)
            {
                if (s.Length < width)
                {
                    int countFreeSpace = width - s.Length;
                    int countWords = s.Split(' ').Length;

                    if (countWords == 1 || countFreeSpace == 1)
                    {
                        ResultString += AddSpaces(s, countFreeSpace) + "\n\r";
                    }
                    else
                    {
                        buf = " " + s;

                        List<int> SpaceIdexes = GetAllIndexes(buf);

                        int lgt = buf.Length;
                        int currentIndex = 0;

                        while (lgt != width)
                        {
                            buf = buf.Insert(SpaceIdexes[currentIndex], " ");
                            lgt += 1;

                            for (int i = currentIndex + 1; i < SpaceIdexes.Count; i++)
                            {
                                SpaceIdexes[i] += 1;
                            }

                            if (currentIndex + 1 < SpaceIdexes.Count)
                            {
                                currentIndex += 1;
                            }
                            else
                            {
                                currentIndex = 0;
                            }
                        }

                        ResultString += buf + "\n\r";
                    }
                }
                else
                {
                    ResultString += s + "\n\r";
                }
            }

            return ResultString;
        }

        private static String AddSpaces(String str, int count)
        {
            return str = new String(' ', count) + str;
        }

        private static List<int> GetAllIndexes(String str)
        {
            List<int> Indexes = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    Indexes.Add(i);
                }
            }

            return Indexes;
        }
    }
}
