﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace RAPID_Syntax_Checker.Tools
{
    class SyntaxChecker
    {
        #region [Variables]
        string _filepath;
        private string project_directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        int _line_stop_number;
        private string line_18, line_19, line_20, line_21, line_23, line_24, line_27, line_stop;
        #endregion

        #region [Constructor]
        public SyntaxChecker(string my_filepath)
        {
            _filepath = my_filepath;
            _line_stop_number = Find_stop();
            get_lines();
        }
        #endregion

        #region [Functions]
        public void get_lines()
        {
            // Read lines into a string array
            string[] lines = File.ReadAllLines(_filepath);
            line_18 = lines[17]; // MoveStn1ToFloorPrint;
            line_19 = lines[18]; // InitializeService;
            line_20 = lines[19]; // InitializeEquipment "obPrintPlate","tWeldGun_180";
            line_21 = lines[20]; // InitializeWeldMode bdSTT_Test1,seSTT_Test1,trkSTT,bdSTT_Test,seSTT_Test,trkSTT;
            line_23 = lines[22]; // MoveJ [[69.32,5.03,589.74],[0.00242807,-0.440161,0.897914,-0.00146465],[-1,-1,-1,1],[9E+09,9E+09,9E+09,9E+09,9E+09,9E+09]], v500, z10, PrintTool\WObj:=PrintWobj;
            line_24 = lines[23]; // SetRGCodeEvents 2;
            line_27 = lines[26]; // SetRGCodeEvents 1;
            line_stop = lines[_line_stop_number]; // Stop;

            #if DEBUG
            MessageBox.Show(line_18 + "\r\n" +  line_19 + "\r\n" + line_20 + "\r\n"+ line_21 + "\r\n" + line_23 + "\r\n" + line_24 + "\r\n" + line_27 + "\r\n" + line_stop);
            #endif
        }

        // Function that find the line number containing "Stop;"
        public int Find_stop()
        { 
            string[] lines = File.ReadAllLines(_filepath);

            for (int i = 0; i < lines.Length; i++)
            {               
                
                if (lines[i].Contains("Stop;"))
                {
                    return i;
                }
                
            }
            return 0;
        }

        // Function for writing text to metadata file
        public void write_metadata()
        {
            string metafile_dir = project_directory + @"\MetaData\MetaFile.txt";

            // Clear the metadata file
            File.Create(metafile_dir).Close();

            // Open file for writing
            StreamWriter streamWriter = new StreamWriter(metafile_dir);

            string[] file_line = File.ReadAllLines(_filepath);

            for ( int i = 0; i < file_line.Length; i++ )
            {
                // Fix indentation
                switch (i)
                {
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                    case 22:
                    case 23:
                    case 26:
                        streamWriter.Write("      " + file_line[i] + "\r\n");
                        break;
                    default:
                        streamWriter.Write(file_line[i] + "\r\n");
                        break;
                }
            }
            streamWriter.Close();
        }

        #endregion

    }
}
