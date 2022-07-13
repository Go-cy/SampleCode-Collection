﻿using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Data.l

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderOpen();
        }

        private void FolderOpen()
        {
            using (CommonOpenFileDialog FolderOpen = new CommonOpenFileDialog())
            {
                FolderOpen.Title = "Select Assembly Mother Folder for updating";
                FolderOpen.Multiselect = true; // 파일 다중 선택        
                FolderOpen.IsFolderPicker = true;
                FolderOpen.InitialDirectory = @"D:\Program_Source_VS2015\PackageApplication\2021";

                if (FolderOpen.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    string[] folderList = FolderOpen.FileNames.ToArray();
                    for (int i = 0; i < folderList.Length; i++)
                    {
                        this.checkedListBox1.Items.Add(folderList[i], true);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void btnAssemblyUpdate_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            string strPattern = "...";
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                StreamReader reading = File.OpenText(this.checkedListBox1.CheckedItems[i].ToString() + @"\Properties\AssemblyInfo.cs");
                while ((str = reading.ReadLine()) != null)
                {
                    if ((str.Contains("[assembly: AssemblyVersion(") || str.Contains("[assembly: AssemblyFileVersion("))
                        && str.IndexOf("//") != 0)
                    {
                        //var version = from c in str
                        //              where SqlMethods.li
                        StreamWriter write = new StreamWriter("test.txt");
                    }
                }
            }
        }
    }
}
