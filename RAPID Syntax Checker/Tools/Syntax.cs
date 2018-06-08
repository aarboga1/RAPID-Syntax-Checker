using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace RAPID_Syntax_Checker.Tools
{
    class Syntax
    {
        #region [Variables]
        string _filepath;
        private string line_18, line_19, line_20, line_21;
        #endregion

        #region [Constructor]
        public Syntax(string my_filepath)
        {
            _filepath = my_filepath;
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

        }
        #endregion
    }
}
