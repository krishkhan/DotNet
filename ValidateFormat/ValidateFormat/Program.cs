using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace ValidateFormat
{
    class Program
    {
        static void Main(string[] args)
        {
            String filePath = @"..\..\IOInfoMap.csv";
            StringBuilder preprocessStore = new StringBuilder();

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        if (null != sr)
                        {
                            String currentLine = String.Empty;
                            while ((currentLine = sr.ReadLine()) != null )
                            {
                                preprocessStore.Append(currentLine).Append(";") ;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Following exception occured " + ex.Message); 
            }

            String[] processStore = preprocessStore.ToString().Split(';');

            VariableValidator.IsVariable("_IO_IU15_12, 1, 5, 12, 58, IO_BOOL");

            Console.WriteLine("Program Ended successfuly");

        }
    }
    class VariableValidator
    {
        public static Boolean IsVariable(String data)
        {
            Boolean isVariable = false ;
            //String rule = "^([A-Za-z0-9_-],[0-9]*,[0-9]*,[0-9]*,[0-9]*,[IO_BOOL][IO_REAL])";
            String rule = "^([A-Za-z0-9_-],[0-9])";
            if( Regex.IsMatch(data,rule))
            {
                Console.WriteLine ("String matched:" + data );

            }
            else
            {
                Console.WriteLine ("String not matched:" + data );
            }
            

            return isVariable ;
        }

    }
    class VariableInfo
    {
        public VariableInfo(String data )
        {

        }
    }
}
